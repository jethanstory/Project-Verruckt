using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickupNoteAdvScr : MonoBehaviour
{
    public GameObject myHands; //reference to your hands/the position where you want your object to go
    // bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    bool hasItem; // a bool to see if you have an item in your hand

    public GameObject notesCanvas;
    public bool activeCanvas;
    public GameObject infoText;
    public GameObject fpsPlayer;

    public Text Txt;
    public int numNotes;

    public GameObject noteCopiedText;
    public GameObject noteOpenFirstTime;
    public float secondsCountCopiedText = 0;
    float secondsCountFirstTime = 0;
    bool triggeredNote = false;
    bool hasBeenCopiedFirst = false;
    bool hasBeenCopiedSecond = false;
    bool hasBeenCopiedThird = false;
    bool openNoteFirstTimeBool = false;

    public GameObject backButton;
    public GameObject firstNoteButton;
    public GameObject secondNoteButton;
    public GameObject thirdNoteButton;

    bool firstNoteTaken;
    bool secondNoteTaken;
    bool thirdNoteTaken;


    public GameObject savedNotesCanvas;

    string sceneName;

    // bool pickedSubsequentNote = false;

    public GameObject noteSecondCanvas;
    public GameObject noteThirdCanvas;


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

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

        if (openNoteFirstTimeBool) // hint to show how to open notebook
        {
            secondsCountFirstTime += Time.deltaTime;
            noteOpenFirstTime.SetActive(true);
            if (secondsCountFirstTime > 10)
            {
                noteOpenFirstTime.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.N) && !fpsPlayer.GetComponent<PauseMenuScr>().activeMenu) // show notebook on 'N' press
        {
            checkNotes();
        }

        if (triggeredNote && (!hasBeenCopiedFirst || !hasBeenCopiedSecond)) // show Copied to Notes text if the note hasn't already been picked up
        {
            // secondsCountCopiedText = 0;
            secondsCountCopiedText += Time.deltaTime;
            noteCopiedText.SetActive(true);
            if (secondsCountCopiedText > 2.5)
            {
                noteCopiedText.SetActive(false);
            }
        }
        // else if (triggeredNote && !hasBeenCopiedSecond)
        // {
        //     // secondsCountCopiedText = 0;
        //     secondsCountCopiedText += Time.deltaTime;
        //     noteCopiedText.SetActive(true);
        //     if (secondsCountCopiedText > 2.5)
        //     {
        //         noteCopiedText.SetActive(false);
        //     }
        // }
        else if (secondsCountCopiedText == 0) // if note trigger has been left and seconds counter reset, set copied text inactive
        {
            noteCopiedText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUpNote")
        {
            if (!openNoteFirstTimeBool)
            {
                openNoteFirstTimeBool = true;
            }
            firstNoteTaken = true;
            triggeredNote = true;
            // canpickup = true;
            ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
            //infoText.SetActive(true);
            notesCanvas.SetActive(true);
            //if (sceneName != "TestStartScene") {
            // if (pickedSubsequentNote) {
            //     if (sceneName == "HallsStart") {
            //         Txt = GameObject.Find ("NoteText").GetComponent<Text> ();
            //         Txt.text = "Ron, \n \n I found your key on the floor in the hall, decided to leave it in room 56 so that you can grab it later. I've taken the liberty to lock the door. \n \n - Becky";
            //     }

            //     if (sceneName == "ReceptionTestStartScene") {
            //         //Txt.text = "CLASSIFIED \n \n Temporal Environmental Adjustment Medication (T.E.A.M) PROGRAM STATUS \n \n SUMMARY: \n \n  It has been concluded that least 200 MG of *REDACTED* Sulfide is required to induce the temporal effects needed to shift the subjects into the temporal realm. For research purposes the *REDACTED* Sulfide was administered via oral ingestion in 10 MG and 25MG capsules. Approximately 13 deaths occured as a result of these studies and a further 15 subjects have slipped into a state of being that is locally refered to as the 'shadow realm'. Research on this phenomenon is still ongoing.";
            //         Txt.text = "PROGRAM REFERENCE NOTE TO HR: \n \n DECLASSIFED ELEMENTS \n \n SUMMARY: \n \n It has been concluded that it would be benefical for HR purposes to declassify a small portion of the nature of the *REDACTED* program. HR Personel may now make reference to an 'experimental medication program involving puzzle solving and cognitive thought' when referring to the *REDACTED* project to any personel without security clearance or outside civilians. No further information will be revealed.";
            //     }
            // }

            // if (fpsPlayer.GetComponent<PickUpObject>().isViewing) {
            //     notesCanvas.SetActive(false);
            // }
            if (fpsPlayer.GetComponent<PickupKeyScr>().firstKeyCollected) // swap text of notes when keys are collected
            {
                Txt = GameObject.Find("NoteText").GetComponent<Text>();
                if (sceneName == "HallsStart")
                {
                    Txt.text = "Ron, \n \n Did you take my key? I can't find it anywhere. \n \n - Becky";
                }
            }
        }

        if (other.gameObject.tag == "PickUpSecondNote")
        {
            if (!openNoteFirstTimeBool) // show hint for opening notebook on first note pickup
            {
                openNoteFirstTimeBool = true;
            }
            // pickedSubsequentNote = true;
            secondNoteTaken = true;
            triggeredNote = true;
            ObjectIwantToPickUp = other.gameObject;

            noteSecondCanvas.SetActive(true);
            //Txt = GameObject.Find ("SecondNoteText").GetComponent<Text> ();
            // if (sceneName == "HallsStart") {
            //     Txt.text = "Becky, \n \n Retrieved the second key from the storage closet. Decided to leave the other key in room 54 and locked the door. Try to meet me in the main hall if you can. \n \n - Ron"; //+ Strength.ToString ();
            // }

            // if (sceneName == "ReceptionTestStartScene") {
            //     Txt.text = "Jake, \n \n Please don't leave the ward key laying around in the filing closet. Return it to me when you're done with it. \n \n - Sal"; //+ Strength.ToString ();
            // }

            // if (fpsPlayer.GetComponent<PickUpObject>().isViewing) {
            // notesCanvas.SetActive(false);
            // }
            if (fpsPlayer.GetComponent<PickupKeyScr>().secondKeyCollected) // swap text of notes when keys are collected
            {
                Txt = GameObject.Find("SecondNoteText").GetComponent<Text>();
                if (sceneName == "HallsStart")
                {
                    Txt.text = "Becky, \n \n I can't seem to find my key anywhere at all. Been searching around. Have you got it?  \n \n - Ron";
                }
            }
        }

        if (numNotes >= 3) // if more than 3 notes in level
        {
            if (other.gameObject.tag == "PickUpThirdNote")
            {
                // canpickup = true;
                ObjectIwantToPickUp = other.gameObject;
                //infoText.SetActive(true);
                thirdNoteTaken = true;
                triggeredNote = true;
                noteThirdCanvas.SetActive(true);
                Txt = GameObject.Find("ThirdNoteText").GetComponent<Text>();
                // if (sceneName == "HallsStart") {
                //     Txt.text = "Becky, \n \n Retrieved the second key from the storage closet. Decided to leave the other key in room 54 and locked the door. Try to meet me in the main hall if you can. \n \n - Ron"; //+ Strength.ToString ();
                // }

                // if (sceneName == "ReceptionTestStartScene") {
                //     Txt.text = "Jake, \n \n Please don't leave the ward key laying around in the filing closet. Return it to me when you're done with it. \n \n - Sal"; //+ Strength.ToString ();
                // }
                // if (fpsPlayer.GetComponent<PickUpObject>().isViewing) {
                // notesCanvas.SetActive(false);
                // }
                if (fpsPlayer.GetComponent<PickupKeyScr>().secondKeyCollected)
                {
                    // Txt = GameObject.Find ("NoteText").GetComponent<Text> ();
                    // Txt.text = "Becky, \n \n I can't seem to find my key anywhere at all. Been searching around. Have you got it?  \n \n - Ron";
                }
            }
        }
        // if(other.gameObject.tag == "PickUpThirdNote") //on the object you want to pick up set the tag to be anything, in this case "object"
        // {
        //     canpickup = true;  //set the pick up bool to true
        //     ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
        //     //infoText.SetActive(true);

        //     noteThirdCanvas.SetActive(true);
        //     Txt = GameObject.Find ("ThirdNoteText").GetComponent<Text> ();
        //     // if (sceneName == "HallsStart") {
        //     //     Txt.text = "Becky, \n \n Retrieved the second key from the storage closet. Decided to leave the other key in room 54 and locked the door. Try to meet me in the main hall if you can. \n \n - Ron"; //+ Strength.ToString ();
        //     // }

        //     // if (sceneName == "ReceptionTestStartScene") {
        //     //     Txt.text = "Jake, \n \n Please don't leave the ward key laying around in the filing closet. Return it to me when you're done with it. \n \n - Sal"; //+ Strength.ToString ();
        //     // }
        //     // if (fpsPlayer.GetComponent<PickUpObject>().isViewing) {
        //     // notesCanvas.SetActive(false);
        //     // }
        //     if (fpsPlayer.GetComponent<PickupKeyScr>().secondKeyCollected) 
        //     {
        //         // Txt = GameObject.Find ("NoteText").GetComponent<Text> ();
        //         // Txt.text = "Becky, \n \n I can't seem to find my key anywhere at all. Been searching around. Have you got it?  \n \n - Ron";
        //     }  


        // }
    }
    private void OnTriggerExit(Collider other)
    {
        notesCanvas.SetActive(false);
        noteSecondCanvas.SetActive(false);
        secondsCountCopiedText = 0;
        triggeredNote = false;



        if (numNotes >= 3) // if more than 3 notes in level
        {
            noteThirdCanvas.SetActive(false);
        }
        if (other.gameObject.tag == "PickUpNote") // if first note has been copied
        {
            hasBeenCopiedFirst = true;
        }
        else if (other.gameObject.tag == "PickUpSecondNote") // if second note has been copied
        {
            hasBeenCopiedSecond = true;
        }
        if ((other.gameObject.tag == "PickUpThirdNote") && numNotes >= 3) // if more than 3 notes in level
        {
            hasBeenCopiedThird = true;
        }
        }

    public void checkNotes() // Notebook brought up by pressing 'N'
    {
        if (activeCanvas)
        {
            activeCanvas = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            savedNotesCanvas.SetActive(false);
            notesCanvas.SetActive(false);
            noteSecondCanvas.SetActive(false);
        }
        else if (!activeCanvas)
        {
            activeCanvas = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            savedNotesCanvas.SetActive(true);
            backButton.SetActive(false);
            if (firstNoteTaken) // show button if note has been picked up
                firstNoteButton.SetActive(true);
            if (secondNoteTaken)
                secondNoteButton.SetActive(true);
            if (thirdNoteTaken)
                thirdNoteButton.SetActive(true);
        }
    }
    public void firstNoteDisplay() // Display first note on button push in Notes Menu
    {
        firstNoteButton.SetActive(false);
        secondNoteButton.SetActive(false);
        thirdNoteButton.SetActive(false);
        notesCanvas.SetActive(true);
        backButton.SetActive(true);
        if (!activeCanvas)
        {
            notesCanvas.SetActive(false);
        }
    }

    public void secondtNoteDisplay() // Display first note on button push in Notes Menu
    {
        firstNoteButton.SetActive(false);
        secondNoteButton.SetActive(false);
        thirdNoteButton.SetActive(false);
        noteSecondCanvas.SetActive(true);
        backButton.SetActive(true);
        if (!activeCanvas)
        {
            noteSecondCanvas.SetActive(false);
        }
    }

    public void thirdNoteDisplay() // Display first note on button push in Notes Menu
    {
        firstNoteButton.SetActive(false);
        secondNoteButton.SetActive(false);
        thirdNoteButton.SetActive(false);
        noteThirdCanvas.SetActive(true);
        backButton.SetActive(true);
        if (!activeCanvas)
        {
            noteThirdCanvas.SetActive(false);
        }
    }

    public void backButtonNotes() // Go back to button menu
    {
        notesCanvas.SetActive(false);
        noteSecondCanvas.SetActive(false);
        noteThirdCanvas.SetActive(false);
        backButton.SetActive(false);
        if (firstNoteTaken)
            firstNoteButton.SetActive(true);
        if (secondNoteTaken)
            secondNoteButton.SetActive(true);
        if (thirdNoteTaken)
            thirdNoteButton.SetActive(true);
        if (!activeCanvas)
        {
            notesCanvas.SetActive(false);
        }
    }
}
