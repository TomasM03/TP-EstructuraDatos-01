using TMPro;
using UnityEngine;
using UnityEngine.UI; // Importar para trabajar con UI
using System.Collections.Generic;

public class ABB : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab; // Prefab para la l�nea
    public GameObject circlePrefab;
    public Button inOrderButton; // Bot�n para In-Order
    public Button preOrderButton; // Bot�n para Pre-Order
    public Button postOrderButton; // Bot�n para Post-Order
    public Button depthButton; // Bot�n para calcular la profundidad
    public int[] myArray = { 20, 10, 1, 26, 35, 40, 18, 12, 15, 14, 30, 23 };

    private void Start()
    {
        // Asignar m�todos a los botones
        inOrderButton.onClick.AddListener(HandleInOrder);
        preOrderButton.onClick.AddListener(HandlePreOrder);
        postOrderButton.onClick.AddListener(HandlePostOrder);
        depthButton.onClick.AddListener(HandleCalculateDepth);

        // Inicializar el �rbol
        StartBinaryTree(myArray);
    }

    private void StartBinaryTree(int[] array)
    {
        // Limpia la escena de c�rculos y l�neas previas
        foreach (var obj in GameObject.FindGameObjectsWithTag("Circle"))
        {
            Destroy(obj);
        }
        foreach (var obj in GameObject.FindGameObjectsWithTag("Line"))
        {
            Destroy(obj);
        }

        // Establecer las posiciones y crear los c�rculos
        Vector2 startPosition = new Vector2(0, 3);
        float verticalSpacing = 2.0f;
        float horizontalSpacing = 2.0f; // Espaciado horizontal
        Vector2[] positions = new Vector2[array.Length];

        CreateBinaryTree(array, startPosition, verticalSpacing, horizontalSpacing, 0, positions);
    }

    private void CreateBinaryTree(int[] array, Vector2 position, float verticalSpacing, float horizontalSpacing, int index, Vector2[] positions)
    {
        if (index < array.Length)
        {
            // Instanciamos el c�rculo
            GameObject newCircle = Instantiate(circlePrefab, position, Quaternion.identity);
            TextMeshProUGUI circleText = newCircle.GetComponentInChildren<TextMeshProUGUI>();
            circleText.text = array[index].ToString();

            // Almacenamos la posici�n
            positions[index] = position;

            // Calcular la nueva posici�n para el hijo izquierdo
            int leftChildIndex = 2 * index + 1;
            Vector2 leftChildPosition = position + new Vector2(-horizontalSpacing / (index + 1), -verticalSpacing);
            CreateBinaryTree(array, leftChildPosition, verticalSpacing, horizontalSpacing, leftChildIndex, positions);

            // Calcular la nueva posici�n para el hijo derecho
            int rightChildIndex = 2 * index + 2;
            Vector2 rightChildPosition = position + new Vector2(horizontalSpacing / (index + 1), -verticalSpacing);
            CreateBinaryTree(array, rightChildPosition, verticalSpacing, horizontalSpacing, rightChildIndex, positions);

            // Dibujar l�neas entre padres e hijos solo si existen
            if (leftChildIndex < array.Length)
            {
                DrawLine(position, leftChildPosition);
            }

            if (rightChildIndex < array.Length)
            {
                DrawLine(position, rightChildPosition);
            }
        }
    }

    public void DrawLine(Vector2 start, Vector2 end)
    {
        if (linePrefab != null)
        {
            GameObject line = Instantiate(linePrefab);
            line.tag = "Line"; // A�adir etiqueta para limpiar m�s tarde
            LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
        }
    }

    // M�todos para manejar los botones y reordenar los c�rculos
    public void HandleInOrder()
    {
        List<int> result = InOrderTraversal(myArray, 0);
        StartBinaryTree(result.ToArray());
    }

    public void HandlePreOrder()
    {
        List<int> result = PreOrderTraversal(myArray, 0);
        StartBinaryTree(result.ToArray());
    }

    public void HandlePostOrder()
    {
        List<int> result = PostOrderTraversal(myArray, 0);
        StartBinaryTree(result.ToArray());
    }

    public void HandleCalculateDepth()
    {
        int depth = CalculateDepth(0); // Comenzar desde la ra�z (�ndice 0)
        Debug.Log("Profundidad del �rbol: " + depth);
    }

    private int CalculateDepth(int index)
    {
        if (index >= myArray.Length) return 0; // Si el �ndice est� fuera de los l�mites, no hay nodo.

        // Calcula la profundidad de los hijos izquierdo y derecho
        int leftDepth = CalculateDepth(2 * index + 1);
        int rightDepth = CalculateDepth(2 * index + 2);

        // La profundidad es 1 (el nodo actual) m�s la profundidad m�xima de los hijos
        return 1 + Mathf.Max(leftDepth, rightDepth);
    }

    // Recorridos
    private List<int> InOrderTraversal(int[] array, int index)
    {
        List<int> result = new List<int>();
        if (index < array.Length)
        {
            result.AddRange(InOrderTraversal(array, 2 * index + 1)); // Hijo izquierdo
            result.Add(array[index]); // Nodo actual
            result.AddRange(InOrderTraversal(array, 2 * index + 2)); // Hijo derecho
        }
        return result;
    }

    private List<int> PreOrderTraversal(int[] array, int index)
    {
        List<int> result = new List<int>();
        if (index < array.Length)
        {
            result.Add(array[index]); // Nodo actual
            result.AddRange(PreOrderTraversal(array, 2 * index + 1)); // Hijo izquierdo
            result.AddRange(PreOrderTraversal(array, 2 * index + 2)); // Hijo derecho
        }
        return result;
    }

    private List<int> PostOrderTraversal(int[] array, int index)
    {
        List<int> result = new List<int>();
        if (index < array.Length)
        {
            result.AddRange(PostOrderTraversal(array, 2 * index + 1)); // Hijo izquierdo
            result.AddRange(PostOrderTraversal(array, 2 * index + 2)); // Hijo derecho
            result.Add(array[index]); // Nodo actual
        }
        return result;
    }
}
