using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 2.0f;
    private Vector3 animationOffset = new Vector3(0,5,5);

    public static bool GameIsPaused = false;
    public GameObject pauseUI;

    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
        backgroundMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + startOffset;
        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);
        if (transition > 1.0f)
        {
            transform.position = moveVector;

        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        backgroundMusic.UnPause();
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        backgroundMusic.Pause();
    }

    public void Exit()
    {
        Application.Quit();
    }


}
