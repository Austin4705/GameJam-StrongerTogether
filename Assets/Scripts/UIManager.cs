using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float score;
    public Text roundCount;
    public Text scoreOutput;
    public Text nanobotOutput;
    
    public Text C4CoolDown;
    public Text C4Unlocked;

    public Text OrbCoolDown;
    public Text OrbUnlocked;

    public Text PiercingCoolDown;
    public Text PiercingUnlocked;
    public Text PiercingDuration;

    public Text CoolDown;
    public Text Unlocked;
    public Text Duration;

    void Update()
    {
        nanobotOutput.text = nanobotSystem.Instance.nanobots.ToString();

        C4CoolDown.text = (Time.time - abilityManager.Instance.C4Timer / abilityManager.Instance.C4CoolDown).ToString();
            setBool(C4Unlocked, abilityManager.Instance.c4Unlocked);
        
    }

    private static UIManager _instance;
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

    void setBool(Text text, bool value)
    {
        if (value)
        {
            text.text = "Yes";
        }
        else
        {
            text.text = "No";
        }
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
}
