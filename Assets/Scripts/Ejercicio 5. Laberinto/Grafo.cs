using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Grafo
{
    public Nodo[,] Nodos { get; set; }

    public Grafo(int filas, int columnas)
    {
        Nodos = new Nodo[filas, columnas];

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                Nodos[i, j] = new Nodo(i, j);
            }
        }

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                if (i > 0 && Nodos[i - 1, j] != null) Nodos[i, j].Vecinos.Add(Nodos[i - 1, j]);
                if (i < filas - 1 && Nodos[i + 1, j] != null) Nodos[i, j].Vecinos.Add(Nodos[i + 1, j]);
                if (j > 0 && Nodos[i, j - 1] != null) Nodos[i, j].Vecinos.Add(Nodos[i, j - 1]);
                if (j < columnas - 1 && Nodos[i, j + 1] != null) Nodos[i, j].Vecinos.Add(Nodos[i, j + 1]);
            }
        }
    }
}

