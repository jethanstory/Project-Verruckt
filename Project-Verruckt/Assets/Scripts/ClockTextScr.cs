using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTextScr : MonoBehaviour
{
    float secondsCount = 0;
    
    public GameObject textControls;
    public GameObject textGoal;

    public GameObject fpsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkClock();
    }

    void checkClock() {
        if (fpsPlayer.GetComponent<PickupClockScr>().hasClock) {

            secondsCount += Time.deltaTime;
            textControls.SetActive(true);

            if (secondsCount > 5) 
            {
                textControls.SetActive(false);
                // textGoal.SetActive(true);
                // if (secondsCount > 10)
                // {
                //     textGoal.SetActive(false);
                // }
            }
        } 
    }
}
