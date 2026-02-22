using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScr : MonoBehaviour
{

    public GameObject menuCanvas;

    public GameObject fpsPlayer;
    public bool activeMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !fpsPlayer.GetComponent<PickupNoteAdvScr>().activeCanvas)
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
        else if (!activeMenu )
        {
            activeMenu = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menuCanvas.SetActive(true);
        }
    }
}
