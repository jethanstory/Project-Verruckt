using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTickScr : MonoBehaviour
{

    float secondsCount = 0;
    
    public GameObject clockStart;
    public GameObject clockRun;
    public GameObject clockRunFast;
    public GameObject clockEnd;
    public GameObject cinematicSound;

    public GameObject fpsPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkPills();
    }

    void checkPills() {
        if (fpsPlayer.GetComponent<PickUpObject>().isViewing) {

            secondsCount += Time.deltaTime;
            clockStart.SetActive(true);
            cinematicSound.SetActive(true);

            if (secondsCount > 0.5) 
            {
                clockStart.SetActive(false);
                clockRun.SetActive(true);
                if (secondsCount >= 20)
                {
                    clockRun.SetActive(false);
                    clockRunFast.SetActive(true);
                    if (secondsCount >= 28)
                    {
                        clockEnd.SetActive(false);
                        clockEnd.SetActive(true);
                        
                    }
                }
            }
        }
        else
        {
            cinematicSound.SetActive(false);
            clockRunFast.SetActive(false);
            secondsCount = 0;
        } 
    }
}
