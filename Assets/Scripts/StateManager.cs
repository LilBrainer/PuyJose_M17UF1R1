using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
        PlayerController.Reset();
    }
    
    public void ChangeSceneByName(string name)
    {
        if (name != null)
        {
            SceneManager.LoadScene(name);
        }
    }
}
