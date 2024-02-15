using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedBiometricIDDoorCheckScr : MonoBehaviour
{

    public bool BioCheck;
    public GameObject textShow;
    public GameObject buzzer;
    public GameObject crouchJumpText;
    public GameObject crouchJumpTrigger;

    public GameObject attachedObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BioCheck = attachedObject.GetComponent<BloodPickupScr>().bloodCollected;
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if (other.gameObject.tag == "BioDoor") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            if (BioCheck == false)
            {
                textShow.SetActive(true);
                buzzer.SetActive(false);
                buzzer.SetActive(true);
            }
            if (BioCheck)
            {
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                SceneManager.LoadScene("labScene");
            }
        }

        if (other.gameObject.tag == "CrouchJump") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            crouchJumpText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textShow.SetActive(false);
        crouchJumpText.SetActive(false);

    }
}
