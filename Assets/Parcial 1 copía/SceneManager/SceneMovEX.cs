using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMovEX : MonoBehaviour
{
    [SerializeField] private Button previous;
    [SerializeField] private Button next;
    [SerializeField] private Button mainMenu;

    private void Start()
    {
        previous.onClick.AddListener(Previous);
        next.onClick.AddListener(Next);
        mainMenu.onClick.AddListener(MainMenu);
    }

    public void Next()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void Previous()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int previousScene = currentScene - 1;
        SceneManager.LoadScene(previousScene);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
