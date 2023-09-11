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


    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        //if (hasClock)
        //if (objectCheck.GetComponent<PlayerClockCheck>().hasClock)
        if (GameObject.Find("ClockCheckObject").GetComponent<PlayerClockCheck>().hasClock)
        {
            GameObject.Find("First Person Player").GetComponent<ClockTickScr>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Clock") //on the object you want to pick up set the tag to be anything, in this case "object"
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
