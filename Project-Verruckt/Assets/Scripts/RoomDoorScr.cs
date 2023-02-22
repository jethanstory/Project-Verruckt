using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoorScr : MonoBehaviour
{
    public GameObject doorLockedSound;
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
        if(other.gameObject.tag == "RoomDoor") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            doorLockedSound.SetActive(false);
            doorLockedSound.SetActive(true);

        }
    }

    
}
