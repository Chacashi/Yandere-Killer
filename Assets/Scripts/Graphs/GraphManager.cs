using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    [Header("Nodos del grafo (asignar en inspector)")]
    public List<GraphNode> allNodes = new List<GraphNode>();

    public GraphNode GetClosestNode(Vector3 position)
    {
        GraphNode closest = null;
        float shortestDistance = float.MaxValue;

        int count = allNodes.Count;
        for (int i = 0; i < count; i++)
        {
            GraphNode node = allNodes[i];
            if (!node.isWalkable) continue;

            float distance = Vector3.Distance(position, node.Position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closest = node;
            }
        }

        return closest;
    }

    public GraphNode GetRandomNeighbor(GraphNode current)
    {
        if (current == null || current.neighbors.Count == 0) return null;

        List<GraphNode> validNeighbors = new List<GraphNode>();
        int count = current.neighbors.Count;
        for (int i = 0; i < count; i++)
        {
            GraphNode neighbor = current.neighbors[i];
            if (neighbor != null && neighbor.isWalkable)
                validNeighbors.Add(neighbor);
        }

        if (validNeighbors.Count == 0) return null;
        return validNeighbors[Random.Range(0, validNeighbors.Count)];
    }
}