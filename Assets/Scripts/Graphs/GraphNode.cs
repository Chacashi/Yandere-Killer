using System.Collections.Generic;
using UnityEngine;

public class GraphNode : MonoBehaviour
{
    [Header("Conexiones a otros nodos")]
    public List<GraphNode> neighbors = new List<GraphNode>();

    [Header("Configuración opcional")]
    public bool isWalkable = true;

    public Vector3 Position => transform.position;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.2f);

        int count = neighbors.Count;
        Gizmos.color = Color.yellow;
        for (int i = 0; i < count; i++)
        {
            if (neighbors[i] != null)
            {
                Gizmos.DrawLine(transform.position, neighbors[i].transform.position);
            }
        }
    }
}
