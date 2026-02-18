using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlashlightScr : MonoBehaviour
{
    GameObject ObjectIwantToDestroy; // the gameobject onwhich you collided with
    //public GameObject flashLightSource;
    public GameObject flashLightPlayer;
    public bool flashLightCollected;
    public bool flashLightTriggerInRange;

    public GameObject pickupFlashlightText;

    void Update()
    {
        if (flashLightTriggerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (ObjectIwantToDestroy != null)
                Destroy(ObjectIwantToDestroy);
            flashLightCollected = true;
            //flashLightSource.SetActive(false);
            // GameObject.Find("playerBody").GetComponent<ThrowingObject>().enabled = true;
            GameObject.Find("First Person Player").GetComponent<FlashLightMech>().enabled = true;
            flashLightPlayer.SetActive(true);
            pickupFlashlightText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Flashlight")
        {
            pickupFlashlightText.SetActive(true);
            flashLightTriggerInRange = true;
            ObjectIwantToDestroy = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        flashLightTriggerInRange = false;
        pickupFlashlightText.SetActive(false);
        // flashLightTriggerInRange = false;
    }
}
