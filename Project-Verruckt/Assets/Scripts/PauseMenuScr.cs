using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScr : MonoBehaviour
{

    public GameObject menuCanvas;
    private bool activeMenu; 


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            checkMenu();
        }
    }

    public void checkMenu()
    {   
        if (activeMenu)
        {
            activeMenu = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            menuCanvas.SetActive(false);
        }
        else
        {
            activeMenu = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menuCanvas.SetActive(true);

        }
    }
}
