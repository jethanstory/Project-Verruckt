using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlashlightScr : MonoBehaviour
{
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToDestroy; // the gameobject onwhich you collided with

    //public GameObject flashLightSource;
    public GameObject flashLightPlayer;

    public bool flashLightCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canpickup == true) // if you enter thecollider of the objecct
        {
            
            
        }
            
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Flashlight") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToDestroy = other.gameObject; //set the gameobject you collided with to one you can reference
            Destroy(ObjectIwantToDestroy);
            flashLightCollected = true;
            //flashLightSource.SetActive(false);
            // GameObject.Find("playerBody").GetComponent<ThrowingObject>().enabled = true;
            GameObject.Find("First Person Player").GetComponent<FlashLightMech>().enabled = true;
            flashLightPlayer.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false
     
    }
}
