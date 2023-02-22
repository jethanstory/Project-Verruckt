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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "DoorStuck") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
           canBeStuck = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canBeStuck = false; 
     
    }

    void TrappedRoom() {
        if (!fpsPlayer.GetComponent<PickUpObject>().isViewing && canBeStuck) {
            playerStuck = true;
        }
        else {
            playerStuck = false;
        }
    }


}
