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

    public bool syringeTriggerInRange;
    public GameObject pickupSyringePressText;
    // Start is called before the first frame update
    void Start()
    { }
    // Update is called once per frame
    void Update()
    {
        if (syringeTriggerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (ObjectIwantToDestroy != null)
                Destroy(ObjectIwantToDestroy);
            syringeCollected = true;
            pickupSound.SetActive(false);
            pickupSound.SetActive(true);
            playerSyringe.SetActive(true);
            pickupSyringePressText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Syringe")
        {
            ObjectIwantToDestroy = other.gameObject; //set the gameobject you collided with to one you can reference
            syringeTriggerInRange = true;
            pickupSyringePressText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        textDisplay.SetActive(false);
        syringeTriggerInRange = false;
        pickupSyringePressText.SetActive(false);
    }
}
