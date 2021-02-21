using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class playButton : MonoBehaviour
{
    public Text highScore;
    //public audio
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnMouseEnter()
    {
        
    }

    public void Start()
    {
        highScore.text = scorePass.highscore.ToString();
    }
    public void quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
