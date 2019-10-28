using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;

    void Start()
    {
        print("set score");
        scoreText.text = "Socre: " + PlayerMotor.distance + " m";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
