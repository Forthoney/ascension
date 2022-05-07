using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    public void GotoNewScene(string newScene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(newScene);
    }

    public void RestartScene()
    {
        Time.timeScale = 1; 
        print("Restarting!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print("Restarting Scene complete");
        
    }
}
