using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isPaused, isGored, canFly;
    public GameObject mainMenu;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        
    }

    public void Pause()
    {
        mainMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoreMode()
    {
        isGored = !isGored;
    }
    


}
