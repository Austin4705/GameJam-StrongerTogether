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
    
    public GameObject C4CoolDown;
    public GameObject C4Unlocked;

    public GameObject OrbCoolDown;
    public GameObject OrbUnlocked;

    public GameObject PiercingCoolDown;
    public GameObject PiercingUnlocked;
    public GameObject PiercingDuration;
    
    public GameObject MachineGunCoolDown;
    public GameObject MachineGunUnlocked;
    public GameObject MachineGunDuration;

    void Update()
    {
        nanobotOutput.text = nanobotSystem.Instance.nanobots.ToString();

        float C4Percentage = capNumber((Time.time - abilityManager.Instance.C4Timer) / abilityManager.Instance.C4CoolDown,
            0, 1, abilityManager.Instance.c4Unlocked);
        C4CoolDown.GetComponent<Image>().fillAmount = C4Percentage;
        setBool(C4Unlocked, abilityManager.Instance.c4Unlocked);
        
        float piercingPercentage = capNumber((Time.time - abilityManager.Instance.piercingTimer) / abilityManager.Instance.piercingCoolDown,
            0, 1, abilityManager.Instance.piercingUnlocked);
        PiercingCoolDown.GetComponent<Image>().fillAmount = piercingPercentage;
        setBool(PiercingUnlocked, abilityManager.Instance.piercingUnlocked);
        if (abilityManager.Instance.piercingEnabled)
        {
            PiercingDuration.GetComponent<Image>().fillAmount = (1-capNumber((Time.time - abilityManager.Instance.piercingTimer) / abilityManager.Instance.piercingActiveTime,
                0, 1, abilityManager.Instance.piercingUnlocked));
        }
        else
        {
            PiercingDuration.GetComponent<Image>().fillAmount = 0;
        }
        
        
        float machineGunPercentage = capNumber((Time.time - abilityManager.Instance.machineGunTimer) / abilityManager.Instance.machineGunCoolDown,
            0, 1, abilityManager.Instance.machineGunUnlocked);
        MachineGunCoolDown.GetComponent<Image>().fillAmount = machineGunPercentage;
        setBool(MachineGunUnlocked, abilityManager.Instance.machineGunUnlocked);
        if (abilityManager.Instance.machineGunEnabled)
        {
            MachineGunDuration.GetComponent<Image>().fillAmount = (1-capNumber((Time.time - abilityManager.Instance.machineGunTimer) / abilityManager.Instance.machineGunActiveTime,
                0, 1, abilityManager.Instance.machineGunUnlocked));
        }
        else
        {
            MachineGunDuration.GetComponent<Image>().fillAmount = 0;
        }

        float orbPercentage = capNumber((Time.time - abilityManager.Instance.orbTimer) / abilityManager.Instance.orbCoolDown,
            0, 1, abilityManager.Instance.orbUnlocked);
        OrbCoolDown.GetComponent<Image>().fillAmount = orbPercentage;
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

    void setBool(GameObject game, bool value)
    {
        game.GetComponent<Image>().enabled = !value;
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
