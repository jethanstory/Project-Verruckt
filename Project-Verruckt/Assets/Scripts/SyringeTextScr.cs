using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeTextScr : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject fpsPlayer;
    public float secondsCount = 0;


    void Update()
    {
        syringeText();
    }


    public void syringeText()
    {
        if (fpsPlayer.GetComponent<PickupSyringeScr>().syringeCollected)
        {
            secondsCount += Time.deltaTime;
            textDisplay.SetActive(true);

            if (secondsCount > 2)
            {
                textDisplay.SetActive(false);
                secondsCount = 100;
            }
        }
    }
}
