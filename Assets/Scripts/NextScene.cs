using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public int sceneToLoad;
    public bool nextScene;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            if(nextScene == true)
            {
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("next scene");
            }
            else
            {
                SceneManager.LoadScene(sceneToLoad);
                Debug.Log("specific scene");
            }


        }
    }
}
