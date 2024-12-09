using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LABMazeNode
{
    public int Row { get; private set; }
    public int Column { get; private set; }

    public LABMazeNode(int row, int column)
    {
        Row = row;
        Column = column;
    }
}
