using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Triggered");
        if (collision.name == "Player")
        {
            if (this.tag == "NextLevel")
            {
                print("Changin to scene " + sceneBuildIndex);
                SceneManager.LoadScene(sceneBuildIndex+1, LoadSceneMode.Single);
            }
            else if (this.tag == "PrevLevel")
            {
                print("Changin to scene " + sceneBuildIndex);
                SceneManager.LoadScene(sceneBuildIndex - 1, LoadSceneMode.Single);
            }
        }
    }

}
