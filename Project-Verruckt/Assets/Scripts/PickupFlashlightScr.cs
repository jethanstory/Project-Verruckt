using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlashlightScr : MonoBehaviour
{
    GameObject ObjectIwantToDestroy; // the gameobject onwhich you collided with
    //public GameObject flashLightSource;
    public GameObject flashLightPlayer;
    public bool flashLightCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Flashlight")
        {
            ObjectIwantToDestroy = other.gameObject;
            Destroy(ObjectIwantToDestroy);
            flashLightCollected = true;
            //flashLightSource.SetActive(false);
            // GameObject.Find("playerBody").GetComponent<ThrowingObject>().enabled = true;
            GameObject.Find("First Person Player").GetComponent<FlashLightMech>().enabled = true;
            flashLightPlayer.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    { }
}
