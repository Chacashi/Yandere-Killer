using UnityEngine;
using System.Collections.Generic;

public class VisionCone : MonoBehaviour
{
    [SerializeField] private float VisionRange = 5f;
    [SerializeField] private float VisionAngle = 90f;
    [SerializeField] private LayerMask VisionObstructingLayer;
    [SerializeField] private int VisionConeResolution = 60;
    [SerializeField] private Color GizmoColor;

    private List<Vector3> conePoints = new List<Vector3>();

    private void Update()
    {
        CalculateVisionCone();
    }

    void CalculateVisionCone()
    {
        conePoints.Clear();

        float halfAngle = VisionAngle * 0.5f;
        float angleStep = VisionAngle / (VisionConeResolution - 1);

        Vector3 origin = transform.position;

        for (int i = 0; i < VisionConeResolution; i++)
        {
            float angle = -halfAngle + angleStep * i;
            float rad = angle * Mathf.Deg2Rad;

            Vector3 direction = (transform.forward * Mathf.Cos(rad)) + (transform.right * Mathf.Sin(rad));
            direction.Normalize();

            Vector3 endPoint = origin + direction * VisionRange;

            if (Physics.Raycast(origin, direction, out RaycastHit hit, VisionRange, VisionObstructingLayer))
            {
                endPoint = hit.point;
            }

            conePoints.Add(endPoint);
        }
    }

    private void OnDrawGizmos()
    {
        if (conePoints == null || conePoints.Count == 0) return;

        Gizmos.color = GizmoColor;

        Vector3 origin = transform.position;

        for (int i = 0; i < conePoints.Count; i++)
        {
            Gizmos.DrawLine(origin, conePoints[i]);

            if (i < conePoints.Count - 1)
            {
                Gizmos.DrawLine(conePoints[i], conePoints[i + 1]);
            }
        }
    }
}
