using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readJSON : MonoBehaviour
{
    public TextAsset jsonFile;

    // Start is called before the first frame update
    void Start()
    {
        rounds level = JsonUtility.FromJson<rounds>(jsonFile.text);
 
        foreach (round Round in level.eachRound)
        {
            Debug.Log(
                "roundID: " + Round.roundID + " " + 
                "roundID: " + Round.grunt + " " +
                "charge: " + Round.charge + " " +
                "ranged: " + Round.ranged + " " +
                "roundTime: " + Round.roundTime + " "
                );
        }
    }
}

