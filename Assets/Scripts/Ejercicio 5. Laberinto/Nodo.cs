using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo
{
    public int X { get; set; }
    public int Y { get; set; }
    public List<Nodo> Vecinos { get; set; }

    public Nodo(int x, int y)
    {
        X = x;
        Y = y;
        Vecinos = new List<Nodo>();
    }
}

