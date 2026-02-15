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


    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FlareGunShellPickup")
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
