using UnityEngine;
using TMPro;


public class UIController : MonoBehaviour
{
    public TextMeshProUGUI textoConjunto;
    private ConjuntoDinamico<int> conjunto;

    void Start()
    {
        conjunto = new ConjuntoDinamico<int>();
        ActualizarTextoConjunto();
    }

    public void AgregarElemento()
    {
      
        conjunto.Add(10);
        ActualizarTextoConjunto();
    }

    public void EliminarElemento()
    {
       
        conjunto.Remove(10);
        ActualizarTextoConjunto();
    }

    public void MostrarConjunto()
    {
        textoConjunto.text = "Conjunto: [" + conjunto.Show() + "]";
    }

    private void ActualizarTextoConjunto()
    {
        textoConjunto.text = "Conjunto: [" + conjunto.Show() + "]";
    }
    public void Cardinalidad()
    {
        int cardinalidad = conjunto.Cardinality();
        textoConjunto.text = "Cardinalidad del conjunto: " + cardinalidad;
    }

    public void EsVacio()
    {
        bool vacio = conjunto.IsEmpty();
        textoConjunto.text = "El conjunto está vacío: " + (vacio ? "Sí" : "No");
    }

    public void Union()
    {
        
        ConjuntoTDA<int> conjuntoB = new ConjuntoDinamico<int>(); 
        ConjuntoTDA<int> union = conjunto.Union(conjuntoB);
        textoConjunto.text = "Unión de los conjuntos: " + union.Show();
    }

    public void Interseccion()
    {
       
        ConjuntoTDA<int> conjuntoB = new ConjuntoDinamico<int>(); 
        ConjuntoTDA<int> interseccion = conjunto.Intersect(conjuntoB);
        textoConjunto.text = "Intersección de los conjuntos: " + interseccion.Show();
    }

    public void Diferencia()
    {
        ConjuntoTDA<int> conjuntoB = new ConjuntoDinamico<int>(); 
        ConjuntoTDA<int> diferencia = conjunto.Difference(conjuntoB);
        textoConjunto.text = "Diferencia de los conjuntos: " + diferencia.Show();
    }
    public void ContainsElemento()
    {
        int elementoABuscar = 10; 
        bool contiene = conjunto.Contains(elementoABuscar);

        textoConjunto.text = "¿Contiene el elemento " + elementoABuscar + "? " + (contiene ? "Sí" : "No");
    }




}


