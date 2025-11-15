using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchScr : MonoBehaviour
{
    public CharacterController controller;


    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = 1.0f;
        }

        else
        {
            controller.height = 2.0f;
        }
    }
}
