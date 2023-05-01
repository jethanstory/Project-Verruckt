using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLockUnlockScr : MonoBehaviour
{
    public GameObject doorLockedSound;
    public GameObject doorStuckSound;

    public GameObject fpsPlayer;
    public bool canLeave = false;

    public int doorStuckCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "ExitDoor") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            checkKey();
            if (canLeave)
            {
                //SceneManager.LoadScene("HallsStart");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                doorStuckCount++;

                if (doorStuckCount > 10)
                {
                    doorStuckSound.SetActive(false);
                    doorStuckSound.SetActive(true);
                    doorStuckCount = 0;
                }
                else
                {
                    doorLockedSound.SetActive(false);
                    doorLockedSound.SetActive(true);
                }
                
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
     
    }

    void checkKey() {
        if (fpsPlayer.GetComponent<PickupKeyScr>().canUnlock) {
            canLeave = true;
        }
        else {
            canLeave = false;
        }
    }

}
