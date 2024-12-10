using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MazeGraph : MonoBehaviour
{
    [SerializeField] private GameObject nodePrefab;
    [SerializeField] private int rows = 5;
    [SerializeField] private int cols = 5;
    [SerializeField] private TextMeshProUGUI isSolvableTxt;
    private MazeNode[,] grid;
    private TdaGraph<MazeNode> graph;

    private void Start()
    {
        isSolvableTxt.gameObject.SetActive(false);
        graph = new TdaGraph<MazeNode>();
        CreateGrid();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = CastRay();
            if (hit.collider != null)
            {
                MazeNode node = hit.collider.GetComponent<MazeNode>();
                if (node != null)
                {
                    ChangeNodeType(node);
                }
            }
        }
    }

    public void CheckSolution()
    {
        CreateConnections();
        isSolvableTxt.gameObject.SetActive(true);
        if (IsMazeSolvable())
        {
            isSolvableTxt.text = "The maze is solvable!";
            isSolvableTxt.color = Color.green;
        }
        else
        {
            isSolvableTxt.text = "The maze is not solvable!";
            isSolvableTxt.color = Color.red;
        }
    }

    private void CreateGrid()
    {
        grid = new MazeNode[rows, cols];
        float offset = 1.1f; // Distancia entre los nodos.

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                // Instancia los nodos y los coloca en la grilla.
                GameObject nodeObj = Instantiate(nodePrefab, new Vector3(col * offset, -row * offset, 0), Quaternion.identity, transform);
                MazeNode node = nodeObj.GetComponent<MazeNode>();
                graph.AddVertex(node); // Añade cada nodo como vértice al grafo.
                grid[row, col] = node; // Guarda el nodo en la matriz.

                TextMeshPro textMesh = nodeObj.GetComponentInChildren<TextMeshPro>();
                if (textMesh != null)
                {
                    textMesh.text = $"{row + 1}/{col + 1}";
                }
            }
        }
    }

    private void ChangeNodeType(MazeNode node)
    {
        if (Input.GetKey(KeyCode.Alpha1))
            node.SetType(MazeNode.NodeType.Entrance);
        else if (Input.GetKey(KeyCode.Alpha2))
            node.SetType(MazeNode.NodeType.Exit);
        else if (Input.GetKey(KeyCode.Alpha3))
            node.SetType(MazeNode.NodeType.Path);
        else if (Input.GetKey(KeyCode.Alpha4))
            node.SetType(MazeNode.NodeType.Wall);
    }

    private void CreateConnections()
    {
        graph.ClearEdges();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                MazeNode node = grid[row, col];
                if (node.Type == MazeNode.NodeType.Wall) continue;

                AddConnections(row, col);
            }
        }
    }

    private void AddConnections(int row, int col)
    {
        MazeNode node = grid[row, col];
        MazeNode[] neighbors = GetNeighbors(row, col);

        foreach (var neighbor in neighbors)
        {
            if (neighbor != null && neighbor.Type != MazeNode.NodeType.Wall)
            {
                graph.AddEdge(node, neighbor, 1);
            }
        }
    }

    private MazeNode[] GetNeighbors(int row, int col)
    {
        MazeNode[] neighbors = new MazeNode[4];
        if (row > 0) neighbors[0] = grid[row - 1, col];
        if (row < rows - 1) neighbors[1] = grid[row + 1, col];
        if (col > 0) neighbors[2] = grid[row, col - 1];
        if (col < cols - 1) neighbors[3] = grid[row, col + 1];
        return neighbors;
    }

    public bool IsMazeSolvable()
    {
        MazeNode start = null, end = null;

        foreach (var vertex in graph.VertexList)
        {
            if (vertex.Type == MazeNode.NodeType.Entrance) start = vertex;
            if (vertex.Type == MazeNode.NodeType.Exit) end = vertex;
        }

        if (start == null || end == null) return false;

        return DepthFirstSearch(start, end, new HashSet<MazeNode>());
    }

    private bool DepthFirstSearch(MazeNode current, MazeNode target, HashSet<MazeNode> visited)
    {
        if (current == target) return true;
        visited.Add(current);

        foreach (var edge in graph.AdjacencyList[current])
        {
            MazeNode neighbor = edge.Item1;
            if (!visited.Contains(neighbor))
            {
                if (DepthFirstSearch(neighbor, target, visited)) return true;
            }
        }
        return false;
    }

    private RaycastHit2D CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
    }
}
