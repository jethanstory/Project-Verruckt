using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCreditsDemoScr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("ClockCheckObject").GetComponent<PlayerClockCheck>().hasClock = false;
    }
}
