using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPickupScr : MonoBehaviour
{
    public bool bloodCollected;
    public GameObject pickupSound;
    //GameObject ObjectIwantToDestroy;

    //public GameObject playerSyringe;
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
        if(other.gameObject.tag == "Blood") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            //canpickup = true;  //set the pick up bool to true
            bloodCollected = true;
            pickupSound.SetActive(false);
            pickupSound.SetActive(true);
            //playerSyringe.SetActive(true);
            //syringeText();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //canpickup = false; //when you leave the collider set the canpickup bool to false
        //textDisplay.SetActive(false);
    }
}
