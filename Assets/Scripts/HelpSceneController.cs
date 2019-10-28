using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpSceneController : MonoBehaviour
{
    private static string MenuScene = "Menu";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickClose()
    {
        SceneManager.LoadScene(MenuScene);
    }
}
