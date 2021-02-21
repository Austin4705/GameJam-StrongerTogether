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
        if(Input.GetButton("Jump") && nextScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
