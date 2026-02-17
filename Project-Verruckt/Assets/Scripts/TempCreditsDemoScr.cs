using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCreditsDemoScr : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        GameObject.Find("ClockCheckObject").GetComponent<PlayerClockCheck>().hasClock = false;
    }
}
