using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedBiometricIDDoorCheckScr : MonoBehaviour
{

    public bool BioCheck;
    public GameObject textShow;
    public GameObject buzzer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "BioDoor") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            if (BioCheck == false)
            {
                textShow.SetActive(true);
                buzzer.SetActive(false);
                buzzer.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textShow.SetActive(false);
     
    }
}
