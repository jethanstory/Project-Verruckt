using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorLockUnlockScr : MonoBehaviour
{

    public CanvasGroup myUIGroup;
    private bool fadeIn;
    private bool fadeOut;


    public GameObject doorLockedSound;
    public GameObject doorStuckSound;

    public GameObject fpsPlayer;
    public bool canLeave = false;
    public bool atDoor = false;

    public int doorStuckCount;


    void Update()
    {
        if (canLeave && atDoor)
        {
            leaveProcedure();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ExitDoor")
        {
            atDoor = true;
            checkKey();
            // if (canLeave)
            // {
            //     // leaveProcedure();
            //     //SceneManager.LoadScene("HallsStart");
            //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // }
            doorStuckCount++;

            // if (doorStuckCount > 10)
            // {
            //     doorStuckSound.SetActive(false);
            //     doorStuckSound.SetActive(true);
            //     doorStuckCount = 0;
            // }
            // else
            // {
            //     doorLockedSound.SetActive(false);
            //     doorLockedSound.SetActive(true);
            // }


            if (!canLeave)
            {
                doorLockedSound.SetActive(false);
                doorLockedSound.SetActive(true);

            }
            if (doorStuckCount > 4) //10
            {
                doorStuckSound.SetActive(false);
                doorStuckSound.SetActive(true);
            }
            // else
            // {
            //     doorStuckCount++;

            //     if (doorStuckCount > 10)
            //     {
            //         doorStuckSound.SetActive(false);
            //         doorStuckSound.SetActive(true);
            //         doorStuckCount = 0;
            //     }
            //     else
            //     {
            //         doorLockedSound.SetActive(false);
            //         doorLockedSound.SetActive(true);
            //     }

            // }
        }
    }
    private void OnTriggerExit(Collider other)
    {


    }

    void checkKey()
    {
        if (fpsPlayer.GetComponent<PickupKeyScr>().canUnlock)
        {
            canLeave = true;
        }
        else
        {
            canLeave = false;
        }
    }

    void leaveProcedure()
    {
        if (myUIGroup.alpha < 1)
        {
            myUIGroup.alpha += Time.deltaTime;
            if (myUIGroup.alpha >= 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                fadeOut = false;
            }
        }
    }

}
