using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering.PostProcessing;

using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PickUpObject : MonoBehaviour
{
    public GameObject myHands; //reference to your hands/the position where you want your object to go
    //bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToDestroy; // the gameobject onwhich you collided with
    public bool hasItem; // a bool to see if you have an item in your hand

    public GameObject pillSound;
    public GameObject pills;
    public GameObject viewSource;
    public GameObject viewSourceVin;
    public GameObject viewSourceVinDuo;
    public GameObject hintSource;
    public GameObject shadowPerson;
    public GameObject realObjects;
    public GameObject otherObjects;
    public GameObject pressEText;
    public bool notColor = false;
    public bool canPill = false;
    public bool isViewing = false;
    public bool doublePilled = false;

    public float pillTime;
    public float maxTime;

    public int pillsTaken;
    public int totalPillsTaken;
    public int maxPillsCanTake;

    public int pillsCollected;

    public GameObject loseCanvas;

    public int maxPillsAvaliable;

    public GameObject fpsPlayer;
    //public GameObject objectCheck;
    public GameObject clockHand;

    public Transform spawnPoint;

    GameObject clockInstance;
    public bool pullClockOut;
    public bool putClockAway;

    public GameObject torchObject;

    public GameObject cinematicSound;

    public bool pickedUpClock;

    public bool canPickUpPill;

    public PostProcessVolume _postProcessVolume;

    public float speed = 1.0f;

    // The target (cylinder) position.
    public Transform handTarget;
    public Transform pocketTarget;


    public PostProcessVolume myPostProcess;

    public bool fadeOut;
    public bool fadeIn;

    public GameObject gameOverSound;

    public Text Txt;

    public string defaultPillTxt = " ";

    //public Collider sphereColl;
    // Start is called before the first frame update
    void Start()
    {
        //canpickup = false;    //setting both to false
        hasItem = false;
        //_postProcessVolume.weight = 0;
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
        if (canPickUpPill && Input.GetKeyDown(KeyCode.E))
        {
            //canpickup = true;  //set the pick up bool to true
            if (ObjectIwantToDestroy != null)
                Destroy(ObjectIwantToDestroy);
            pillsCollected += 1;
            pillSound.SetActive(false);
            pillSound.SetActive(true);
            hasItem = true;
            pressEText.SetActive(false);
            canPickUpPill = false;
        }

        //if (fpsPlayer.GetComponent<PickupClockScr>().hasClock)
        //if (objectCheck.GetComponent<PlayerClockCheck>().hasClock)
        if (GameObject.Find("ClockCheckObject").GetComponent<PlayerClockCheck>().hasClock) // || GameObject.Find("ClockCheckObjectTemp").GetComponent<PlayerClockCheck>().hasClock)
        {
            if (pullClockOut)
            {
                var step = speed * Time.deltaTime; // calculate distance to move
                clockHand.transform.position = Vector3.MoveTowards(clockHand.transform.position, handTarget.position, step);

                // Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(clockHand.transform.position, handTarget.position) < 0.0001f)//< 0.001f)
                {
                    // Swap the position of the cylinder.
                    pullClockOut = false;
                }
            }

            if (putClockAway)
            {
                var step = speed * Time.deltaTime; // calculate distance to move
                clockHand.transform.position = Vector3.MoveTowards(clockHand.transform.position, pocketTarget.position, step);

                // Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(clockHand.transform.position, pocketTarget.position) < 0.0001f)//< 0.001f)
                {
                    // Swap the position of the cylinder.
                    putClockAway = false;
                    clockHand.SetActive(false);
                }
            }
        }

        // if (pullClockOut)
        // {
        //     var step =  speed * Time.deltaTime; // calculate distance to move
        //     clockHand.transform.position = Vector3.MoveTowards(clockHand.transform.position, handTarget.position, step);

        //     // Check if the position of the cube and sphere are approximately equal.
        //     if (Vector3.Distance(clockHand.transform.position, handTarget.position) < 0.0001f)//< 0.001f)
        //     {
        //         // Swap the position of the cylinder.
        //         pullClockOut = false;
        //     }
        // }

        // if (putClockAway)
        // {
        //     var step =  speed * Time.deltaTime; // calculate distance to move
        //     clockHand.transform.position = Vector3.MoveTowards(clockHand.transform.position, pocketTarget.position, step);

        //     // Check if the position of the cube and sphere are approximately equal.
        //     if (Vector3.Distance(clockHand.transform.position, pocketTarget.position) < 0.0001f)//< 0.001f)
        //     {
        //         // Swap the position of the cylinder.
        //         putClockAway = false;
        //         clockHand.SetActive(false);
        //     }
        // }


        if (Input.GetKeyDown(KeyCode.V) && pillsCollected >= 1)
        {
            // fadeIn = true;
            // fadeOut = false;
            torchObject.SetActive(false);
            isViewing = true;
            viewSource.SetActive(true); //viewSource.SetActive(false);
            hintSource.SetActive(true);
            otherObjects.SetActive(true);
            realObjects.SetActive(false);
            clockHand.SetActive(true);
            cinematicSound.SetActive(true);
            //clockInstance = Instantiate(clockHand, spawnPoint.position, spawnPoint.rotation);
            pullClockOut = true;

            pillsCollected -= 1;
            pillsTaken += 1;
            totalPillsTaken += 1;

            //fpsPlayer.GetComponent<PickupNoteScr>().notesCanvas.SetActive(false);
            fpsPlayer.GetComponent<PickupNoteAdvScr>().notesCanvas.SetActive(false);
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
            // if (_postProcessVolume.weight < 1)
            //     _postProcessVolume.weight = pillTime;
            //_postProcessVolume.weight = 1;

            if (pillTime >= maxTime)
            {
                cinematicSound.SetActive(false);
                viewSource.SetActive(false); //viewSource.SetActive(true);
                hintSource.SetActive(false);
                otherObjects.SetActive(false);
                realObjects.SetActive(true);
                shadowPerson.SetActive(false);
                pillsTaken -= 1;
                isViewing = false;
                putClockAway = true;
                // fadeIn = false;
                // fadeOut = true;

                if (fpsPlayer.GetComponent<PickupFlashlightScr>().flashLightCollected)
                {
                    torchObject.SetActive(true);
                }

                //clockHand.SetActive(false);
                //Destroy(clockInstance);
            }
            if (pillsTaken > maxPillsCanTake)
            {
                //maxTime = pillTime;
                shadowPerson.SetActive(true);
                //pillTime += 30;
                maxTime = 60;
                Debug.Log("Monkey");
                doublePilled = true;
            }
            if (totalPillsTaken >= maxPillsAvaliable && !fpsPlayer.GetComponent<PickupKeyScr>().canUnlock && !isViewing)
            {
                // gameOverSound.SetActive(false);
                gameOverSound.SetActive(true);
                loseCanvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            // if (fadeIn)
            // {
            //     if (myPostProcess.weight < 1)
            //     {
            //         myPostProcess.weight += 20 * Time.deltaTime; // 20 * 
            //         if (myPostProcess.weight >= 1)
            //         {
            //             fadeIn = false;
            //         }
            //     }
            // }
            // if (fadeOut)
            // {
            //     if (myPostProcess.weight >= 0)
            //     {
            //         myPostProcess.weight -= Time.deltaTime;
            //         if (myPostProcess.weight == 0)
            //         {
            //             fadeOut = false;
            //         }
            //     }
            // }

        }

        if (fpsPlayer.GetComponent<PauseMenuScr>().activeMenu)
        {
            Txt = GameObject.Find("PillNumber").GetComponent<Text>();
            Txt.text = pillsCollected.ToString();
        }

        if (!fpsPlayer.GetComponent<PauseMenuScr>().activeMenu)
        {
            Txt = GameObject.Find("PillNumber").GetComponent<Text>();
            Txt.text = defaultPillTxt;
        }

        else
        {
            //_postProcessVolume.weight = 0;
            pillTime = 0;
            //pillSound.SetActive(false);
        }
        //if (Input.GetKeyDown("q") && hasItem == true) // if you have an item and get the key to remove the object, again can be any key
        // {
        // ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again

        // ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands
        //}
    }


    private void OnTriggerEnter(Collider other) // to see when the player enters the collider //OnTriggerStay
    {
        if (other.gameObject.tag == "Pills") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            pressEText.SetActive(true);
            canPickUpPill = true;
            ObjectIwantToDestroy = other.gameObject; //set the gameobject you collided with to one you can reference
        }
    }
    private void OnTriggerExit(Collider other)
    {
        pressEText.SetActive(false);
        canPickUpPill = false;
        //canpickup = false; //when you leave the collider set the canpickup bool to false
    }

}
