using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    public Graph<VisualNode> graph;
    [SerializeField] private GameObject[] vertexPrefabs;
    [SerializeField] private GameObject traveler;
    [SerializeField] private TextMeshProUGUI travelCost;
    private VisualNode currentDestination;
    private Stack<VisualNode> pathToDestination = new Stack<VisualNode>();
    private int totalTravelCost;

    private void Awake()
    {
        Debug.Log(traveler);
        graph = new Graph<VisualNode>();

        for (int i = 0; i < vertexPrefabs.Length; i++)
        {
            vertexPrefabs[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            VisualNode visualNode = new VisualNode(i + 1);
            graph.AddNode(visualNode);
        }
        NodeConnections();
        currentDestination = graph.nodeList[0];
        traveler.transform.position = new Vector2(vertexPrefabs[0].transform.position.x, vertexPrefabs[0].transform.position.y);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = IdentifyNode();
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Node"))
                TravelToDestination(hit);
        }
    }

    private void NodeConnections()
    {
        graph.AddConnection(graph.nodeList[0], graph.nodeList[1], 5);
        graph.AddConnection(graph.nodeList[0], graph.nodeList[2], 6);
        graph.AddConnection(graph.nodeList[1], graph.nodeList[3], 8);
        graph.AddConnection(graph.nodeList[3], graph.nodeList[2], 3);
        graph.AddConnection(graph.nodeList[3], graph.nodeList[5], 7);
        graph.AddConnection(graph.nodeList[2], graph.nodeList[5], 5);
        graph.AddConnection(graph.nodeList[2], graph.nodeList[4], 6);
        graph.AddConnection(graph.nodeList[5], graph.nodeList[6], 8);
        graph.AddConnection(graph.nodeList[4], graph.nodeList[6], 3);
    }

    private RaycastHit2D IdentifyNode()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        return hit;
    }

    private void TravelToDestination(RaycastHit2D hit)
    {
        GameObject node = hit.collider.gameObject;
        int nodeIndex = int.Parse(node.GetComponentInChildren<TextMeshProUGUI>().text);
        VisualNode visualNode = new VisualNode(nodeIndex);
        visualNode = graph.GetNode(visualNode);
        totalTravelCost = 0;
        pathToDestination.Push(graph.nodeList[nodeIndex - 1]);
        CreatePath(currentDestination, graph.nodeList[nodeIndex - 1]);
        if (pathToDestination.Count > 0)
        {
            StartCoroutine(TravelerAnimations());
        }
    }

    private IEnumerator TravelerAnimations()
    {
        int visualNodeId;
        while (pathToDestination.Count > 0)
        {
            visualNodeId = pathToDestination.Pop().NodeID;
            totalTravelCost += graph.GetTravelCost(currentDestination, graph.nodeList[visualNodeId - 1]);
            Debug.Log(vertexPrefabs[visualNodeId - 1]);
            traveler.transform.position = vertexPrefabs[visualNodeId - 1].transform.position;
            currentDestination = graph.GetNode(graph.nodeList[visualNodeId - 1]);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log(totalTravelCost);
        travelCost.text = totalTravelCost.ToString();
    }

    private void CreatePath(VisualNode start, VisualNode destination)
    {
        foreach (var connections in graph.adjacencyList)
        {
            foreach (var edge in connections.Value)
            {
                if (edge.Item1 == graph.GetNode(destination))
                {
                    if (connections.Key.NodeID == start.NodeID)
                    {
                        Debug.Log("Processing1");
                        return;
                    }
                    else
                    {
                        Debug.Log("Processing2");
                        pathToDestination.Push(connections.Key);
                        CreatePath(start, connections.Key);
                        return;
                    }
                }
            }
        }
    }
}
