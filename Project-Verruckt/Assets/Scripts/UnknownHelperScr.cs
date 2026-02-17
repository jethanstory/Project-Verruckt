using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnknownHelperScr : MonoBehaviour
{
    public GameObject firstHelperItem;

    void Start()
    { }

    void Update()
    { }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if (other.gameObject.tag == "FirstHelperTrigger") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            firstHelperItem.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    { }
}
