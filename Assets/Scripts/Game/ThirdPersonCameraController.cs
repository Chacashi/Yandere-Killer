using UnityEngine;
using Unity.Cinemachine;
using Unity.Mathematics;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("Cinemachine")]
    private CinemachineOrbitalFollow orbital;
    [SerializeField] private Vector2 limitVerticalAxis;
    private float currentVerticalAxis;

    [Header("Sensitivity")]
    [Range(0,1),SerializeField] private float sensitivity;

    private void OnEnable()
    {
        InputReader.OnMoveCamera += GetInput;
    }
    private void OnDisable()
    {
        InputReader.OnMoveCamera -= GetInput;
    }

    private void Awake()
    {
        orbital = GetComponent<CinemachineOrbitalFollow>();
    }
    private void Start()
    {
        currentVerticalAxis=orbital.VerticalAxis.Value;
    }
    private void GetInput(Vector2 input)
    {
        orbital.HorizontalAxis.Value += input.x* sensitivity;

        currentVerticalAxis -= input.y * sensitivity;
        currentVerticalAxis = math.clamp(currentVerticalAxis, limitVerticalAxis.x, limitVerticalAxis.y);
        orbital.VerticalAxis.Value = currentVerticalAxis;
    }

}
