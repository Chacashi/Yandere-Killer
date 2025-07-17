using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    [Header("Movimiento del jugador")]
    private Vector2 inputMovement;
    private Vector3 movement;

    [SerializeField] private float velocity = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("Referencia a la cámara")]
    [SerializeField] private Transform cameraTransform;

    private void OnEnable()
    {
        InputReader.OnMove += Movement;
    }

    private void OnDisable()
    {
        InputReader.OnMove -= Movement;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        movement = camRight * inputMovement.x + camForward * inputMovement.y;

        characterController.Move(movement * velocity * Time.deltaTime);

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    public void Movement(Vector2 move)
    {
        inputMovement = move;
    }
}
