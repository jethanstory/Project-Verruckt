using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrappedRoomScr : MonoBehaviour
{

    public bool playerStuck = false;
    public bool canBeStuck = false;

    public GameObject fpsPlayer;
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
            SceneManager.LoadScene("GameOver");
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
