using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMovement : MonoBehaviour
{
    [SerializeField] private Button excercise1;
    [SerializeField] private Button excercise2;
    [SerializeField] private Button excercise3;
    [SerializeField] private Button excercise4;
    [SerializeField] private Button excercise5;

    private void Start()
    {
        excercise1.onClick.AddListener(Excersise1);
        excercise2.onClick.AddListener(Excersise2);
        excercise3.onClick.AddListener(Excersise3);
        excercise4.onClick.AddListener(Excersise4);
        excercise5.onClick.AddListener(Excersise5);
    }

    private void Excersise1()
    {
        SceneManager.LoadScene("1.ABB");
    }
    private void Excersise2()
    {
        SceneManager.LoadScene("2.AVL");
    }
    private void Excersise3()
    {
        SceneManager.LoadScene("3. Conjunto TDA");
    }
    private void Excersise4()
    {
        SceneManager.LoadScene("4. Graph");
    }
    private void Excersise5()
    {
        SceneManager.LoadScene("5.Laberinto");
    }
}
