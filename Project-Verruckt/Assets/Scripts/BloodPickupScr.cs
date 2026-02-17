using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPickupScr : MonoBehaviour
{
    public bool bloodCollected;
    public GameObject pickupSound;

    void Update()
    { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blood")
        {
            bloodCollected = true;
            pickupSound.SetActive(false);
            pickupSound.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    { }
}
