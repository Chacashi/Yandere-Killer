using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [Header("Configuración general")]
    [SerializeField] private Transform playerReference;
    [SerializeField] private NPCVision[] npcVisions;
    [SerializeField] private NPCController[] npcControllers;
    [SerializeField] private NPCBehaviorSelector[] npcBehaviors;

    private void Awake()
    {
        for (int i = 0; i < npcVisions.Length; i++)
        {
            npcVisions[i].SetPlayerReference(playerReference);
        }

        for (int i = 0; i < npcControllers.Length; i++)
        {
            npcControllers[i].Initialize();
        }
    }

    private void Update()
    {
        for (int i = 0; i < npcControllers.Length; i++)
        {
            NPCBehavior behavior = npcBehaviors[i].CurrentBehavior;

            switch (behavior)
            {
                case NPCBehavior.Patrol:
                    npcControllers[i].Patrol();
                    break;
                case NPCBehavior.Flee:
                    npcControllers[i].FleeFrom(playerReference);
                    break;
                case NPCBehavior.Idle:
                default:
                    npcControllers[i].Stop();
                    break;
            }
        }
    }
}