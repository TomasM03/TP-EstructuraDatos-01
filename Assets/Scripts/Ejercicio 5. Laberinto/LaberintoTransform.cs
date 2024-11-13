using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaberintoVisualizer : MonoBehaviour
{
    public GameObject paredPrefab;
    public GameObject caminoPrefab;
    public Laberinto laberinto;

    void Start()
    {
        laberinto = new Laberinto(5, 5);
        laberinto.GenerarLaberinto();
        MostrarLaberinto();
    }

    void MostrarLaberinto()
    {
        for (int i = 0; i < laberinto.matriz.GetLength(0); i++)
        {
            for (int j = 0; j < laberinto.matriz.GetLength(1); j++)
            {
                Vector3 posicion = new Vector3(i, 0, j);

                if (laberinto.matriz[i, j] == 1)
                {
                    Instantiate(paredPrefab, posicion, Quaternion.identity);
                }
                else
                {
                    Instantiate(caminoPrefab, posicion, Quaternion.identity);
                }
            }
        }
    }
}



