using TMPro;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int filas = 5;      // Número de filas del laberinto
    public int columnas = 5;   // Número de columnas del laberinto
    public GameObject celdaPrefab;  // Prefab para la celda
    public float distancia = 2.0f;  // Distancia entre las celdas

    void Start()
    {
        CrearLaberinto();
    }

    void CrearLaberinto()
    {
        for (int i = 1; i <= filas; i++)
        {
            for (int j = 1; j <= columnas; j++)
            {
                // Crear la celda en las posiciones (i, j)
                Vector2 position = new Vector3(j * distancia, i * distancia);
                GameObject celda = Instantiate(celdaPrefab, position, Quaternion.identity);

                // Crear un identificador para cada celda
                string identificador = i + "/" + j;

                // Crear un objeto de texto para mostrar el identificador
                TextMeshPro texto = celda.GetComponentInChildren<TextMeshPro>();
                if (texto != null)
                {
                    texto.text = identificador;
                }
            }
        }
    }
}
