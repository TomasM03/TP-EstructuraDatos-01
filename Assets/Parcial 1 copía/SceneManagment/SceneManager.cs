using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Excersice1()
    {
        SceneManager.LoadScene("Ejercicio 1");
    }
    public void Excersice2()
    {
        SceneManager.LoadScene("Ejercicio 2");
    }
    public void Excersice3()
    {
        SceneManager.LoadScene("Ejercicio 3");
    }
    public void Excersice4()
    {
        SceneManager.LoadScene("Ejercicio 4");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
