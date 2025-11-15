using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoorScr : MonoBehaviour
{
    public GameObject doorLockedSound;
    public GameObject doorStuckSound;
    public int doorStuckCount;

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if (other.gameObject.tag == "RoomDoor") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
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
