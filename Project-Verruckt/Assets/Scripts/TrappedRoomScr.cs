using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrappedRoomScr : MonoBehaviour
{

    public bool playerStuck = false;
    public bool canBeStuck = false;

    public GameObject fpsPlayer;

    public GameObject loseCanvas;

    void Update()
    {
        TrappedRoom();
        if (playerStuck)
        {
            loseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            //SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DoorStuck")
        {
            canBeStuck = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        canBeStuck = false;

    }

    void TrappedRoom()
    {
        if (!fpsPlayer.GetComponent<PickUpObject>().isViewing && canBeStuck)
        {
            playerStuck = true;
        }
        else
        {
            playerStuck = false;
        }
    }


}
