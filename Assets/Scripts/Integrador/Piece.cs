
using UnityEngine;

public class Piece : MonoBehaviour
{
    private enum TipoCelda { Ninguna, Inicio, Final, Piso, Pared }
    private TipoCelda tipoSeleccionado = TipoCelda.Ninguna;

    public Camera cam;

    // Update is called once per frame
    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClicEnLaberinto();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) tipoSeleccionado = TipoCelda.Inicio;
        if (Input.GetKeyDown(KeyCode.Alpha2)) tipoSeleccionado = TipoCelda.Final;
        if (Input.GetKeyDown(KeyCode.Alpha3)) tipoSeleccionado = TipoCelda.Piso;
        if (Input.GetKeyDown(KeyCode.Alpha4)) tipoSeleccionado = TipoCelda.Pared;
    }

    private void ClicEnLaberinto()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            GameObject celdaClickeada = hit.collider.gameObject;
            CambiarColor(celdaClickeada, tipoSeleccionado);
        }
    }

    void CambiarColor(GameObject celda, TipoCelda tipo)
    {
        Renderer renderer = celda.GetComponent<Renderer>();
        if (renderer != null)
        {
            switch (tipo)
            {
                case TipoCelda.Inicio:
                    renderer.material.color = Color.blue; // Azul para inicio
                    break;
                case TipoCelda.Final:
                    renderer.material.color = Color.red;   // Rojo para final
                    break;
                case TipoCelda.Piso:
                    renderer.material.color = Color.white; // Blanco para piso
                    break;
                case TipoCelda.Pared:
                    renderer.material.color = Color.gray; // Negro para pared
                    break;
            }
        }
    }
}

