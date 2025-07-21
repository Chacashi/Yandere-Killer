using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NPCController : MonoBehaviour
{
    [Header("Patrullaje")]
    [SerializeField] private Transform[] pathNodes;
    [SerializeField] private float baseSpeed = 3f;
    [SerializeField] private float nodeReachThreshold = 1f;

    [Header("Fuga")]
    [SerializeField] private float fleeMultiplier = 2f;

    private CharacterController controller;
    private int currentNodeIndex = 0;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Initialize()
    {
        // Inicialización 
    }

    public void Patrol()
    {
        MoveTowards(pathNodes[currentNodeIndex].position, baseSpeed);

        float distance = Vector3.Distance(transform.position, pathNodes[currentNodeIndex].position);
        if (distance <= nodeReachThreshold)
        {
            currentNodeIndex = (currentNodeIndex + 1) % pathNodes.Length;
        }
    }

    public void FleeFrom(Transform target)
    {
        Vector3 directionAway = (transform.position - target.position).normalized;
        Vector3 fleeTarget = transform.position + directionAway;
        MoveTowards(fleeTarget, baseSpeed * fleeMultiplier);
    }

    public void Stop()
    {
        controller.Move(Vector3.zero);
    }

    private void MoveTowards(Vector3 targetPosition, float speed)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;

        Vector3 flatDirection = new Vector3(direction.x, 0, direction.z);
        if (flatDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(flatDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }

        Vector3 move = flatDirection * speed;
        move.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(move * Time.deltaTime);
    }
}
