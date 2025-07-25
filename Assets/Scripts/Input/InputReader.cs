using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputReader : MonoBehaviour
{
    public static event Action<Vector2> OnMove;
    public static event Action<Vector2> OnMoveCamera;

    private void OnEnable()
    {
        GameManager.OnInputRequested += ProvideInputReader;
    }
    private void OnDisable()
    {
        GameManager.OnInputRequested -= ProvideInputReader;
    }
    private InputReader ProvideInputReader()
    {
        return this;
    }
    public void Movement(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context.ReadValue<Vector2>());
    }
    public void MovementCamera(InputAction.CallbackContext context)
    {
        OnMoveCamera?.Invoke(context.ReadValue<Vector2>().normalized);
    }
}
