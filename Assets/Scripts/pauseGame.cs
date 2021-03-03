using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour
{
	public bool isPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused) {
			Time.timeScale = 1f;
			isPaused = false;
			}
			else {
			Time.timeScale = 0f;
			isPaused = true;
			}
        }
    }
}
