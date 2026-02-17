using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTextScr : MonoBehaviour
{
    float secondsCount = 0;
    public GameObject textControls;
    public GameObject textGoal;
    public GameObject fpsPlayer;


    void Update()
    {
        checkClock();
    }

    void checkClock()
    {
        //if (fpsPlayer.GetComponent<PickupClockScr>().hasClock) {
        if (GameObject.Find("ClockCheckObject").GetComponent<PlayerClockCheck>().hasClock)
        {
            secondsCount += Time.deltaTime;
            textControls.SetActive(true);

            if (secondsCount > 5)
            {
                textControls.SetActive(false);
            }
        }
    }
}
