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

            if (secondsCount > 0.5) 
            {
                clockStart.SetActive(false);
                clockRun.SetActive(true);
                if (secondsCount >= 20 && !fpsPlayer.GetComponent<PickUpObject>().doublePilled) 
                {
                    clockRun.SetActive(false);
                    clockRunFast.SetActive(true);
                    if (secondsCount >= 28 && !fpsPlayer.GetComponent<PickUpObject>().doublePilled)
                    {
                        clockEnd.SetActive(false);
                        clockEnd.SetActive(true);
                        
                    }
                }

                // if (fpsPlayer.GetComponent<PickUpObject>().doublePilled)
                // {
                //     clockRun.SetActive(false);
                //     clockStart.SetActive(true);
                //     clockRun.SetActive(true);
                // }

                // if (secondsCount > 20 && fpsPlayer.GetComponent<PickUpObject>().doublePilled)
                // {
                //     clockRun.SetActive(true);
                //     clockRunFast.SetActive(false);
                // }

                if (secondsCount >= 50 && fpsPlayer.GetComponent<PickUpObject>().doublePilled)
                {
                    //clockStart.SetActive(false);
                    clockRun.SetActive(false);
                    clockRunFast.SetActive(true);
                    if (secondsCount >= 58 && fpsPlayer.GetComponent<PickUpObject>().doublePilled)
                    {
                        clockEnd.SetActive(false);
                        clockEnd.SetActive(true);
                        
                    }
                }
            }
        }
        // if (fpsPlayer.GetComponent<PickUpObject>().isViewing && fpsPlayer.GetComponent<PickUpObject>().doublePilled) {

        //     //secondsCount += Time.deltaTime;
        //     //clockStart.SetActive(true);

        //     if (secondsCount >= 20) 
        //     {
        //         //clockStart.SetActive(false);
        //         clockRun.SetActive(true);
        //         if (secondsCount >= 50)
        //         {
        //             clockRun.SetActive(false);
        //             clockRunFast.SetActive(true);
        //             if (secondsCount >= 58)
        //             {
        //                 clockEnd.SetActive(false);
        //                 clockEnd.SetActive(true);
                        
        //             }
        //         }
        //     }
        // }
        else
        {
            clockRunFast.SetActive(false);
            secondsCount = 0;
        } 
    }
}
