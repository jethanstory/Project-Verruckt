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

    void Start()
    { }

    void Update()
    {
        BioCheck = attachedObject.GetComponent<BloodPickupScr>().bloodCollected;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BioDoor")
        {
            if (BioCheck == false)
            {
                textShow.SetActive(true);
                buzzer.SetActive(false);
                buzzer.SetActive(true);
            }
            if (BioCheck)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                // SceneManager.LoadScene("labScene");
            }
        }

        if (other.gameObject.tag == "CrouchJump")
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
