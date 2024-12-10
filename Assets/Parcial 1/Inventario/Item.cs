using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string Name;
    public string Type;
    public int Value;

    public Item(string name, string type, int value)
    {
        Name = name;
        Type = type;
        Value = value;
    }
}

