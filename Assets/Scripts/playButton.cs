﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class playButton : MonoBehaviour
{

    public void play()
    {
        Debug.LogError("stressed");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
