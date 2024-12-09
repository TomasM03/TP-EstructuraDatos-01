using System.Collections.Generic;

public class TdaGraph<T>
{
    public List<T> VertexList { get; private set; }
    public Dictionary<T, List<(T, int)>> AdjacencyList { get; private set; }

    public TdaGraph()
    {
        VertexList = new List<T>();
        AdjacencyList = new Dictionary<T, List<(T, int)>>();
    }

    public void AddVertex(T vertex)
    {
        if (!VertexList.Contains(vertex))
        {
            VertexList.Add(vertex);
            AdjacencyList[vertex] = new List<(T, int)>();
        }
    }

    public void AddEdge(T from, T to, int weight)
    {
        if (AdjacencyList.ContainsKey(from))
        {
            AdjacencyList[from].Add((to, weight));
        }
    }

    public void ClearEdges()
    {
        foreach (var key in AdjacencyList.Keys)
        {
            AdjacencyList[key].Clear();
        }
    }
}
