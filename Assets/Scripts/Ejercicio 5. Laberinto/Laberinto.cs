using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laberinto
{
    public int[,] matriz;
    public Laberinto(int filas, int columnas)
    {
        matriz = new int[filas, columnas];

        GenerarLaberinto();
    }

    public void GenerarLaberinto()
    {
        matriz = new int[5, 5]
        {
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 1, 1, 0, 1 }
        };
    }

    public void MostrarLaberinto()
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write(matriz[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

