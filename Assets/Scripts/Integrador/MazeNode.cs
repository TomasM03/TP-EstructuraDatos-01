using UnityEngine;

public class MazeNode : MonoBehaviour
{
    public enum NodeType { None, Entrance, Exit, Path, Wall }
    public NodeType Type { get; private set; } = NodeType.None;

    public void SetType(NodeType type)
    {
        Type = type;
        switch (type)
        {
            case NodeType.Entrance:
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case NodeType.Exit:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case NodeType.Path:
                GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case NodeType.Wall:
                GetComponent<SpriteRenderer>().color = Color.gray;
                break;
        }
    }
}
