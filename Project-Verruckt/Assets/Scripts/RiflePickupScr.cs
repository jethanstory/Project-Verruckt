using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePickupScr : MonoBehaviour
{
    public GameObject origRifle;
    public GameObject rifleDoorWire;
    public GameObject rifleTriggerWire;
    public GameObject rifleVertWire;
    public GameObject rifleUnderDeskWire;
    public GameObject pickedUpRifle;
    public bool riflePickedUp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if (other.gameObject.tag == "RiflePickup") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            riflePickedUp = true;
            origRifle.SetActive(false);
            pickedUpRifle.SetActive(true);
            rifleTriggerWire.SetActive(false);
            rifleUnderDeskWire.SetActive(false);
            rifleVertWire.SetActive(false);
            rifleDoorWire.SetActive(false);
        }
    }
}
