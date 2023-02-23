using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

 
public class PickUpObject : MonoBehaviour
{
    public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToDestroy; // the gameobject onwhich you collided with
    public bool hasItem; // a bool to see if you have an item in your hand

    public GameObject pillSound;
    public GameObject pills;
    public GameObject viewSource;
    public GameObject hintSource;
    public GameObject shadowPerson;
    public GameObject realObjects;
    public GameObject otherObjects;
    public bool notColor = false;
    public bool canPill = false;
    public bool isViewing = false;
    public float pillTime;
    public float maxTime;

    public int pillsTaken;
    public int totalPillsTaken;
    public int maxPills;

    public int pillsCollected;

    public GameObject loseCanvas;

    public int maxPillsAvaliable;

    public GameObject fpsPlayer;

    //public Collider sphereColl;
    // Start is called before the first frame update
    void Start()
    {
        canpickup = false;    //setting both to false
        hasItem = false;

        pillSound.SetActive(false);

        //sphereColl = GetComponent<Collider>();
    }
    
 
    // Update is called once per frame
    void Update()
    {
        // if(canpickup == true) // if you enter thecollider of the objecct
        // {
        //     //Debug.Log("HIT");


        //         //sphereColl.enabled = !sphereColl.enabled;
        //     //if (Input.GetKeyDown("e"))  // can be e or any key
        //     //{
        //     pillSound.SetActive(false);
        //     pillSound.SetActive(true);
            
            
        //     //canPill = true;
        //     //pillTime = 0;
            
        //         //Destroy(pills);
                
                

        //         //GameObject.Find("playerBody").GetComponent<ThrowingObject>().enabled = true;

        //         //ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        //         //ObjectIwantToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
        //         //ObjectIwantToPickUp.transform.rotation = myHands.transform.rotation; // sets the position of the object to your hand position
        //         //ObjectIwantToPickUp.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands
                
        //     //}
        // }

        if (Input.GetKeyDown(KeyCode.V) && pillsCollected >= 1)
        {
            isViewing = true;
            viewSource.SetActive(true); //viewSource.SetActive(false);
            hintSource.SetActive(true);
            otherObjects.SetActive(true);
            realObjects.SetActive(false);

            pillsCollected -= 1;
            pillsTaken += 1;
            totalPillsTaken += 1;
            
            // if (notColor == false)
            //     {
                    
            //         viewSource.SetActive(true);
            //         notColor = true;
            //     }

            // else if (notColor == true)
            // {
                
            //     viewSource.SetActive(false);
            //     notColor = false;
            // }  
        }

        if (isViewing)
        {
            pillTime += Time.deltaTime;

            if (pillTime >= maxTime)
            {
                viewSource.SetActive(false); //viewSource.SetActive(true);
                hintSource.SetActive(false);
                otherObjects.SetActive(false);
                realObjects.SetActive(true);
                shadowPerson.SetActive(false);
                pillsTaken -= 1;
                isViewing = false;
            }
            if (pillsTaken > maxPills)
            {
                shadowPerson.SetActive(true);
            }
            if (totalPillsTaken >= maxPillsAvaliable && !fpsPlayer.GetComponent<PickupKeyScr>().canUnlock && !isViewing)
            {
                loseCanvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }

        } 
        else
        {
            pillTime = 0;
            //pillSound.SetActive(false);
        }
        //if (Input.GetKeyDown("q") && hasItem == true) // if you have an item and get the key to remove the object, again can be any key
       // {
           // ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again
         
           // ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands
        //}
    }

    
   private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Pills") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            //canpickup = true;  //set the pick up bool to true
            ObjectIwantToDestroy = other.gameObject; //set the gameobject you collided with to one you can reference
            Destroy(ObjectIwantToDestroy);
            pillsCollected += 1;
            pillSound.SetActive(false);
            pillSound.SetActive(true);
            hasItem = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false
    }
    
}
