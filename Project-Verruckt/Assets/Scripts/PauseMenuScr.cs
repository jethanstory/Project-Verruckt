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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            checkMenu();
        }
    }

    public void checkMenu()
    {
        if (activeMenu) //|| fpsPlayer.GetComponent<PickupNoteAdvScr>().activeCanvas)
        {
            activeMenu = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            menuCanvas.SetActive(false);
        }
        else if (!activeMenu && !fpsPlayer.GetComponent<PickupNoteAdvScr>().activeCanvas)
        {
            activeMenu = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menuCanvas.SetActive(true);
        }
    }
}
