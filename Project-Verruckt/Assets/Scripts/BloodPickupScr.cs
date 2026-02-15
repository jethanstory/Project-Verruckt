using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPickupScr : MonoBehaviour
{
    public bool bloodCollected;
    public GameObject pickupSound;
    //GameObject ObjectIwantToDestroy;

    //public GameObject playerSyringe;

    void Update()
    {
        //syringeText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blood")
        {
            bloodCollected = true;
            pickupSound.SetActive(false);
            pickupSound.SetActive(true);
            //playerSyringe.SetActive(true);
            //syringeText();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //textDisplay.SetActive(false);
    }
}
