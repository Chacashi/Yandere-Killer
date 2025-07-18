using Unity.Cinemachine;
using UnityEngine;
public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("Cinemachine")]
    private CinemachineOrbitalFollow orbital;

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

    private void GetInput(Vector2 input)
    {
        orbital.HorizontalAxis.Value += input.x* sensitivity;
        orbital.VerticalAxis.Value -= input.y* sensitivity/2;
    }

}
