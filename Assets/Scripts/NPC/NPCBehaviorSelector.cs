using UnityEngine;

public enum NPCBehavior
{
    Idle,
    Patrol,
    Flee
}

[RequireComponent(typeof(NPCVision))]
public class NPCBehaviorSelector : MonoBehaviour
{
    public NPCBehavior CurrentBehavior { get; private set; } = NPCBehavior.Patrol;

    [Header("Opciones de Comportamiento")]
    [SerializeField] private float fleeDuration = 5f;

    private NPCVision vision;
    private float fleeTimer = 0f;

    private void Awake()
    {
        vision = GetComponent<NPCVision>();
    }

    private void Update()
    {
        if (vision.CanSeePlayer())
        {
            if (PlayerActionManager.Instance.IsAttacking())
            {
                StartFleeing();
            }
        }

        if (CurrentBehavior == NPCBehavior.Flee)
        {
            fleeTimer -= Time.deltaTime;
            if (fleeTimer <= 0f)
            {
                CurrentBehavior = NPCBehavior.Patrol;
            }
        }
    }

    private void StartFleeing()
    {
        if (CurrentBehavior != NPCBehavior.Flee)
        {
            CurrentBehavior = NPCBehavior.Flee;
            fleeTimer = fleeDuration;
        }
    }
}
