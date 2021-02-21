using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class playButton : MonoBehaviour
{
    //public audio
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnMouseEnter()
    {
        
    }

    public void quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
