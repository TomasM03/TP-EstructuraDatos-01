using System.Collections.Generic;

public class Graph<T>
{
    public List<T> nodeList;
    public Dictionary<T, List<(T, int)>> adjacencyList;

    public Graph()
    {
        nodeList = new List<T>();
        adjacencyList = new Dictionary<T, List<(T, int)>>();
    }

    public void AddNode(T node)
    {
        if (GetNode(node) == null)
        {
            nodeList.Add(node);
            adjacencyList.Add(node, new List<(T, int)>());
        }
    }

    public T GetNode(T node)
    {
        foreach (var n in nodeList)
        {
            if (n.Equals(node))
                return n;
        }
        return default;
    }

    public void AddConnection(T start, T destination, int travelCost)
    {
        if (!ConnectionExists(start, destination))
            adjacencyList[GetNode(start)].Add((GetNode(destination), travelCost));
    }

    public bool ConnectionExists(T start, T destination)
    {
        if (adjacencyList.ContainsKey(start))
        {
            foreach (var node in adjacencyList[start])
                if (node.Item1.Equals(GetNode(destination)))
                    return true;
        }
        return false;
    }

    public int GetTravelCost(T start, T destination)
    {
        if (ConnectionExists(start, destination))
        {
            foreach (var node in adjacencyList[GetNode(start)])
                if (node.Item1.Equals(GetNode(destination)))
                    return node.Item2;
        }
        return -1;
    }
}
