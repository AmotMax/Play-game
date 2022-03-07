using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI, gameCanvas;
    public AudioSource bebop;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(true);
        gameCanvas.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        bebop.volume = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                pauseMenuUI.SetActive(false);
                gameCanvas.SetActive(true);
                Time.timeScale = 1f;
                isPaused = false;
                bebop.volume = 0.3f;
            }
            else
            {
                pauseMenuUI.SetActive(true);
                gameCanvas.SetActive(false);
                Time.timeScale =0f;
                isPaused = true;
                bebop.volume = 0.8f;
            }

        }



    }

    public void Pause()
    {
        if (isPaused)
        {
            pauseMenuUI.SetActive(false);
            gameCanvas.SetActive(true);
            Time.timeScale = 1f;
            isPaused = false;
            bebop.volume = 0.3f;
        }
        else
        {
            pauseMenuUI.SetActive(true);
            gameCanvas.SetActive(false);
            Time.timeScale = 0f;
            isPaused = true;
            bebop.volume = 0.8f;
        }
    }
}
