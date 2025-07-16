using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        
    }
}
