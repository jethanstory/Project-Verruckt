using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrappedRoomScr : MonoBehaviour
{

    public bool playerStuck = false;
    public bool playerMerge = false;
    public bool canBeStuck = false;
    public bool canBeMerged = false;

    public GameObject fpsPlayer;

    public GameObject loseCanvas;
    public GameObject loseCanvasMerged;
    public GameObject gameOverSound;

    void Update()
    {
        TrappedRoom();
        MergeArea();
        if (playerStuck)
        {
            //gameOverSound.SetActive(false);
            gameOverSound.SetActive(true);
            loseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            //SceneManager.LoadScene("GameOver");
        }
        if (playerMerge)
        {
            //gameOverSound.SetActive(false);
            gameOverSound.SetActive(true);
            loseCanvasMerged.SetActive(true);
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
        if (other.gameObject.tag == "DodgyPillsKillArea")
        {
            canBeMerged = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "DoorStuck")
        {
            canBeStuck = false;
        }
        if (other.gameObject.tag == "DodgyPillsKillArea")
        {
            canBeMerged = false;

        }
    }

    void TrappedRoom()
    {
        if (!fpsPlayer.GetComponent<PickUpObject>().isViewing && canBeStuck && fpsPlayer.GetComponent<PickUpObject>().totalPillsTaken > 0) // == fpsPlayer.GetComponent<PickUpObject>().pillsCollected)
        {
            playerStuck = true;
        }
        else
        {
            playerStuck = false;
        }
    }
    void MergeArea()
    {
        if (!fpsPlayer.GetComponent<DodgyPillScr>().dodgyPillTaken && canBeMerged && fpsPlayer.GetComponent<DodgyPillScr>().dPillsTotalTaken > 0)
        {
            playerMerge = true;
        }
        else
        {
            playerMerge = false;
        }
    }


}
