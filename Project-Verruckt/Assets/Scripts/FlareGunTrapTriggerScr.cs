using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareGunTrapTriggerScr : MonoBehaviour
{

    public GameObject origFlareTrap;
    public GameObject newFlareTrap;
    public GameObject flareDoorWire;
    public GameObject flareTriggerWire;
    public GameObject flareVertWire;
    public bool flareShellPickedUp;
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
        if (other.gameObject.tag == "FlareGunShellPickup") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            flareShellPickedUp = true;
            flareDoorWire.SetActive(false);
            flareTriggerWire.SetActive(false);
            flareVertWire.SetActive(false);
            newFlareTrap.SetActive(true);
            origFlareTrap.SetActive(false);
        }
    }
}
