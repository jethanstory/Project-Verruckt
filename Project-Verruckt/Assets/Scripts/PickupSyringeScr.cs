using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSyringeScr : MonoBehaviour
{

    public bool syringeCollected;
    public GameObject pickupSound;
    GameObject ObjectIwantToDestroy;
    public float secondsCount;

    public GameObject playerSyringe;
    public GameObject textDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //syringeText();
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Syringe") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            //canpickup = true;  //set the pick up bool to true
            ObjectIwantToDestroy = other.gameObject; //set the gameobject you collided with to one you can reference
            Destroy(ObjectIwantToDestroy);
            syringeCollected = true;
            pickupSound.SetActive(false);
            pickupSound.SetActive(true);
            playerSyringe.SetActive(true);
            //syringeText();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //canpickup = false; //when you leave the collider set the canpickup bool to false
        textDisplay.SetActive(false);
    }
}
