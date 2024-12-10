using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class Objectives : MonoBehaviour
{
    private Queue<string> objectives;

    public TMP_Text taskText;

    public void Awake()
    {
        objectives = new Queue<string>();
    }

    private void Start()
    {
        objectives.Enqueue("Lavar la casa");
        objectives.Enqueue("Comprar comida");
        objectives.Enqueue("Acomodar pieza");
        objectives.Enqueue("Sacar basura");

        ShowTask();
    }

    public void DoTasks()
    {
        if (objectives.Count > 0)
        {
            ShowTask();
        }
        else
        {
            taskText.text = "No hay más tareas.";
        }
    }

    private void ShowTask()
    {
        string currentTask = objectives.Dequeue();
        taskText.text = currentTask;
    }
}
