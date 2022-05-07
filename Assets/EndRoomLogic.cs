using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRoomLogic : MonoBehaviour
{

    public string nextScene;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player"))
        {
            Time.timeScale = 1;
            print("level complete!");
            SceneManager.LoadScene(nextScene);
        }
    }
}
