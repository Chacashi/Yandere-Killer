using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Event
    public static event Func<InputReader> OnInputRequested;

    [Header("Input Reader Data")]
    private InputReader input;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        input = OnInputRequested?.Invoke();
        EnableCursor(true);
    }
    public void EnableInput(bool enabled)
    {
        input.enabled = enabled;
    }
    public void EnableCursor(bool enabled)
    {
        if(enabled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
    }
}
