using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lose : MonoBehaviour
{
    public float score;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        score = 6;
        text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}