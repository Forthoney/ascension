using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }

        
    }


    public void RestartScene()
    {
        Time.timeScale = 1; 
        print("Restarting!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print("Restarting Scene complete");

    }
}
