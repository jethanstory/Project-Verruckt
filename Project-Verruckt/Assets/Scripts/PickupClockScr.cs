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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Clock")
        {
            ObjectIwantToDestroy = other.gameObject; //set the gameobject you collided with to one you can reference
            Destroy(ObjectIwantToDestroy);
            // objectCheck.GetComponent<PlayerClockCheck>().hasClock = true;
            GameObject.Find("ClockCheckObject").GetComponent<PlayerClockCheck>().hasClock = true;
            pickupClockSound.SetActive(true);
            //hasClock = true;
        }
    }
}
