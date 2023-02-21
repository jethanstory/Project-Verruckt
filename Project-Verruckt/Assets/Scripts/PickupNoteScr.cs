using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupNoteScr : MonoBehaviour
{

    public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    bool hasItem; // a bool to see if you have an item in your hand


    public GameObject notePad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canpickup == true && Input.GetKeyDown(KeyCode.N)) // if you enter thecollider of the objecct
        {
            //Debug.Log("HIT");
            

                //sphereColl.enabled = !sphereColl.enabled;
            //if (Input.GetKeyDown("e"))  // can be e or any key
            //{
                //Destroy(radio);

                //GameObject.Find("playerBody").GetComponent<ThrowingObject>().enabled = true;
                canpickup = false;
                ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                ObjectIwantToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
                ObjectIwantToPickUp.transform.rotation = myHands.transform.rotation; // sets the position of the object to your hand position
                ObjectIwantToPickUp.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands
                    
                
            //}
        }
        else if (canpickup == false && Input.GetKeyDown(KeyCode.N))
        {
            notePad.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "PickUpNote") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false
     
    }

}
