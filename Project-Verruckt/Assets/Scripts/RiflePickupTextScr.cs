using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePickupTextScr : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject fpsPlayer;
    public float secondsCount = 0;

    // Update is called once per frame
    void Update()
    {
        rifleText();
    }

    public void rifleText()
    {
        if (fpsPlayer.GetComponent<RiflePickupScr>().riflePickedUp)
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
