using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaberintoResuelto
{
    public static List<Nodo> EncontrarCamino(Grafo grafo, Nodo inicio, Nodo salida)
    {
        Queue<Nodo> cola = new Queue<Nodo>();
        Dictionary<Nodo, Nodo> padres = new Dictionary<Nodo, Nodo>();
        HashSet<Nodo> visitados = new HashSet<Nodo>();

        cola.Enqueue(inicio);
        visitados.Add(inicio);

        while (cola.Count > 0)
        {
            Nodo nodoActual = cola.Dequeue();

            if (nodoActual == salida)
            {
                List<Nodo> camino = new List<Nodo>();
                Nodo nodo = salida;
                while (nodo != null)
                {
                    camino.Add(nodo);
                    nodo = padres.ContainsKey(nodo) ? padres[nodo] : null;
                }
                camino.Reverse();
                return camino;
            }

            foreach (var vecino in nodoActual.Vecinos)
            {
                if (!visitados.Contains(vecino))
                {
                    cola.Enqueue(vecino);
                    visitados.Add(vecino);
                    padres[vecino] = nodoActual;
                }
            }
        }

        return null;
    }
}

