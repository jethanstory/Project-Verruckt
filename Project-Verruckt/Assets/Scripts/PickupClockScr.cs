using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupClockScr : MonoBehaviour
{
    public bool hasClock;
    string sceneName;
    GameObject ObjectIwantToDestroy;
    public GameObject objectCheck;
    public GameObject pickupClockSound;

    public GameObject pickupClockPressText;
    public bool pickupClockTrigger;


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        // if (sceneName == "ReceptionTestStartScene")
        // {
        //     hasClock = false;
        // }
        // if (objectCheck.GetComponent<PickupClockScr>().hasClock)
        // {
        //     hasClock = true;
        // }
    }


    void Update()
    {
        //if (hasClock)
        //if (objectCheck.GetComponent<PlayerClockCheck>().hasClock)
        if (GameObject.Find("ClockCheckObject").GetComponent<PlayerClockCheck>().hasClock)
        {
            GameObject.Find("First Person Player").GetComponent<ClockTickScr>().enabled = true;
        }
        if (pickupClockTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (ObjectIwantToDestroy != null)
                Destroy(ObjectIwantToDestroy);
            GameObject.Find("ClockCheckObject").GetComponent<PlayerClockCheck>().hasClock = true;
            pickupClockSound.SetActive(true);
            pickupClockPressText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Clock")
        {
            ObjectIwantToDestroy = other.gameObject; //set the gameobject you collided with to one you can reference
            pickupClockPressText.SetActive(true);
            pickupClockTrigger = true;
            // objectCheck.GetComponent<PlayerClockCheck>().hasClock = true;
            //hasClock = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        pickupClockTrigger = false;
        pickupClockPressText.SetActive(false);
    }
}
