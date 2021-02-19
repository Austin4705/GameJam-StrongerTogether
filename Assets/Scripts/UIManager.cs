using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public float score;
    public Text roundCount;
    public Text scoreOutput;
    public static UIManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void addScore(float value)
    {
        score = score + value;
        scoreOutput.text = score.ToString();
    }
    public void setRound(string value)
    {
        roundCount.text = value;
    }
    
    // Update is called once per frame
    void Update()
    {
         
    }
}
