using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareGunTrapShellPickupTextScr : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject fpsPlayer;
    public float secondsCount = 0;

    void Update()
    {
        flareShellText();
    }
    public void flareShellText()
    {
        if (fpsPlayer.GetComponent<FlareGunTrapTriggerScr>().flareShellPickedUp)
        {
            //secondsCount = 0;
            secondsCount += Time.deltaTime;
            textDisplay.SetActive(true);

            if (secondsCount > 2)
            {
                textDisplay.SetActive(false);
                //endTime = true;
                secondsCount = 100;
                // textGoal.SetActive(true);
                // if (secondsCount > 10)
                // {
                //     textGoal.SetActive(false);
                // }
            }

        }
    }
}
