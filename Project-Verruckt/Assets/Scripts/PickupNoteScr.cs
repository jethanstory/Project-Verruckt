using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupNoteScr : MonoBehaviour
{

    public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    bool hasItem; // a bool to see if you have an item in your hand

    public GameObject notesCanvas;
    public bool activeCanvas;
    public GameObject infoText;
    public GameObject fpsPlayer;

    public Text Txt;

    

    public GameObject noteSecondCanvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(canpickup == true && Input.GetMouseButtonDown(0)) // if you enter thecollider of the objecct Input.GetKeyDown(KeyCode.N)
                // canpickup = false;
                // ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                // ObjectIwantToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
                // ObjectIwantToPickUp.transform.rotation = myHands.transform.rotation; // sets the position of the object to your hand position
                // ObjectIwantToPickUp.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands  
        //}
        // else if (canpickup == false && Input.GetMouseButtonDown(0))
        // {
        //     notePad.SetActive(false);
        // }

        // if (Input.GetKeyDown(KeyCode.N))
        // {
        //     checkNotes();
        // }
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "PickUpNote") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
            //infoText.SetActive(true);
            notesCanvas.SetActive(true);
            Txt = GameObject.Find ("NoteText").GetComponent<Text> ();
            Txt.text = "Ron, \n \n Left one of the 2 keys for the Outer Wing in room 56 so that you can grab it later. I've taken the liberty to lock the door just in case. \n \n - Becky";
            if (fpsPlayer.GetComponent<PickUpObject>().isViewing) {
            notesCanvas.SetActive(false);
            }


        }

        if(other.gameObject.tag == "PickUpSecondNote") //on the object you want to pick up set the tag to be anything, in this case "object"
        {

            canpickup = true;  //set the pick up bool to true
            ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
            //infoText.SetActive(true);
            
            notesCanvas.SetActive(true);
            Txt = GameObject.Find ("NoteText").GetComponent<Text> ();
            Txt.text = "Becky, \n \n Wasn't sure where you went. Decided to leave the Outer Wing key in the other room and locked the door. Try to meet me in the main hall if you can. \n \n - Ron"; //+ Strength.ToString ();
            if (fpsPlayer.GetComponent<PickUpObject>().isViewing) {
            notesCanvas.SetActive(false);
            }


        }
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false
        //infoText.SetActive(false);
        notesCanvas.SetActive(false);
     
    }

    public void checkNotes()
    {   
        if (activeCanvas)
        {
            activeCanvas = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            notesCanvas.SetActive(false);
        }
        else
        {
            activeCanvas = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            notesCanvas.SetActive(true);

        }
    }

}
