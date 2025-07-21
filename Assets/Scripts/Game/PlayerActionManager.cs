using UnityEngine;

public class PlayerActionManager : MonoBehaviour
{
    private enum PlayerActionState
    {
        Normal,
        Attack,
        Talk,
        Sneak
    }

    [Header("Estado actual del jugador")]
    [SerializeField] private PlayerActionState currentState = PlayerActionState.Normal;

    public static PlayerActionManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool IsAttacking()
    {
        return currentState == PlayerActionState.Attack;
    }

    public void ToggleAttackState()
    {
        if (currentState == PlayerActionState.Attack)
            currentState = PlayerActionState.Normal;
        else
            currentState = PlayerActionState.Attack;
    }

    public bool IsInNormalState()
    {
        return currentState == PlayerActionState.Normal;
    }
}
