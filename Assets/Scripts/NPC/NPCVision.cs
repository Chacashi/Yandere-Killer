using UnityEngine;

public class NPCVision : MonoBehaviour
{
    [Header("Vision Settings")]
    [SerializeField] private Transform player;
    [SerializeField] private float viewDistance = 10f;
    [SerializeField] private float fieldOfView = 90f;

    private bool playerVisible;

    public bool CanSeePlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > viewDistance)
            return false;

        float dotProduct = Vector3.Dot(transform.forward, directionToPlayer);
        float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        if (angle < fieldOfView / 2f)
        {
            Ray ray = new Ray(transform.position + Vector3.up, directionToPlayer);
            if (Physics.Raycast(ray, out RaycastHit hit, viewDistance))
            {
                if (hit.transform == player)
                {
                    playerVisible = true;
                    return true;
                }
            }
        }

        playerVisible = false;
        return false;
    }

    public void SetPlayerReference(Transform playerTransform)
    {
        player = playerTransform;
    }

    public bool IsPlayerVisible()
    {
        return playerVisible;
    }
}
