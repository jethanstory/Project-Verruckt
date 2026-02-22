using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKeyScr : MonoBehaviour
{
    GameObject ObjectIwantToDestroy; // the gameobject onwhich you collided with

    public GameObject keySound;

    public int keysCollected;
    public int maxKeys; // total keys in level

    public bool canUnlock;
    public bool firstKeyCollected;
    public bool secondKeyCollected;
    public GameObject pickupKeyPressText;
    public bool pickupKeyTrigger;
    public bool pickupSecondKeyTrigger;

    void Start()
    {

    }


    void Update()
    {
        if (keysCollected >= maxKeys)
        {
            canUnlock = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && pickupKeyTrigger)
        {
            if (ObjectIwantToDestroy != null)
                Destroy(ObjectIwantToDestroy);
            keysCollected += 1;
            firstKeyCollected = true;
            keySound.SetActive(false);
            keySound.SetActive(true);
            pickupKeyPressText.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && pickupSecondKeyTrigger)
        {
            if (ObjectIwantToDestroy != null)
                Destroy(ObjectIwantToDestroy);
            keysCollected += 1;
            secondKeyCollected = true;
            keySound.SetActive(false);
            keySound.SetActive(true);
            pickupKeyPressText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if (other.gameObject.tag == "Key") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToDestroy = other.gameObject; //set the gameobject you collided with to one you can reference
            pickupKeyPressText.SetActive(true);
            pickupKeyTrigger = true;
        }

        if (other.gameObject.tag == "SecondKey") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToDestroy = other.gameObject; //set the gameobject you collided with to one you can reference
            pickupKeyPressText.SetActive(true);
            pickupSecondKeyTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Key") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            pickupKeyTrigger = false;
            pickupKeyPressText.SetActive(false);
        }

        if (other.gameObject.tag == "SecondKey") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            pickupKeyPressText.SetActive(false);
            pickupSecondKeyTrigger = false;
        }
        canpickup = false; //when you leave the collider set the canpickup bool to false
    }
}
