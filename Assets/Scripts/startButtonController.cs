﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButtonController : MonoBehaviour
{
    private const string GameScene = "GameScene";
    private const string HelpScene = "Help";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickStart()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void ClickHelp()
    {
        SceneManager.LoadScene(HelpScene);
    }
}
