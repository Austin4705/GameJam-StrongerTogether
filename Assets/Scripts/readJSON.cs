using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readJSON
{
    public static TextAsset jsonFile;
    public static rounds level;
    
    // Start is called before the first frame update
    public static void read()
    {
        level = JsonUtility.FromJson<rounds>(jsonFile.text);
        
        //printing rounds
        foreach (round Round in level.eachRound)
        {
            Debug.Log(
                "roundID: " + Round.roundID + " " + 
                "roundID: " + Round.grunt + " " +
                "roundTime: " + Round.roundTime + " "
            );
                foreach (Special special in Round.special)
                {
                    Debug.Log(
                        "type: " + special.type + " " + 
                        "time: " + special.time + " " +
                        "amount: " + special.amount + " "
                    );
                }
        }
    }
}

