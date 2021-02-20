using System;
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

    public Text MachineGunCoolDown;
    public Text MachineGunUnlocked;
    public Text MachineGunDuration;

    void Update()
    {
        nanobotOutput.text = nanobotSystem.Instance.nanobots.ToString();

        float C4Percentage = capNumber((Time.time - abilityManager.Instance.C4Timer) / abilityManager.Instance.C4CoolDown,
            0, 1, abilityManager.Instance.c4Unlocked);
        C4CoolDown.text = C4Percentage.ToString();
        setBool(C4Unlocked, abilityManager.Instance.c4Unlocked);
        
        float piercingPercentage = capNumber((Time.time - abilityManager.Instance.piercingTimer) / abilityManager.Instance.piercingCoolDown,
            0, 1, abilityManager.Instance.piercingUnlocked);
        PiercingCoolDown.text = piercingPercentage.ToString();
        setBool(PiercingUnlocked, abilityManager.Instance.piercingUnlocked);
        if (abilityManager.Instance.piercingEnabled)
        {
            PiercingDuration.text = (1-capNumber((Time.time - abilityManager.Instance.piercingTimer) / abilityManager.Instance.piercingActiveTime,
                0, 1, abilityManager.Instance.piercingUnlocked)).ToString();
        }
        else
        {
            PiercingDuration.text = 0.ToString();
        }
        
        
        float machineGunPercentage = capNumber((Time.time - abilityManager.Instance.machineGunTimer) / abilityManager.Instance.machineGunCoolDown,
            0, 1, abilityManager.Instance.machineGunUnlocked);
        MachineGunCoolDown.text = machineGunPercentage.ToString();
        setBool(MachineGunUnlocked, abilityManager.Instance.machineGunUnlocked);
        if (abilityManager.Instance.machineGunEnabled)
        {
            MachineGunDuration.text = (1-capNumber((Time.time - abilityManager.Instance.machineGunTimer) / abilityManager.Instance.machineGunActiveTime,
                0, 1, abilityManager.Instance.machineGunUnlocked)).ToString();
        }
        else
        {
            MachineGunDuration.text = 0.ToString();
        }

        float orbPercentage = capNumber((Time.time - abilityManager.Instance.orbTimer) / abilityManager.Instance.orbCoolDown,
            0, 1, abilityManager.Instance.orbUnlocked);
        OrbCoolDown.text = orbPercentage.ToString();
        setBool(OrbUnlocked, abilityManager.Instance.orbUnlocked);
        
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

    float capNumber(float value, float capBottom, float capTop, bool zeroBoolean)
    {
        if (!zeroBoolean)
        {
            return 0;
        }
        else if (value < capBottom)
        {
            return capBottom;
        }
        else if (value > capTop)
        {
            return capTop;
        }
        else
        {
            return value;
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
