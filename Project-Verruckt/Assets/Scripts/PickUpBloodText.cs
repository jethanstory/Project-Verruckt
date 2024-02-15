using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBloodText : MonoBehaviour
{
    float secondsCount = 0;

    public GameObject textControls;

    public GameObject fpsPlayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkBlood();
    }

    void checkBlood()
    {
        //if (fpsPlayer.GetComponent<PickupClockScr>().hasClock) {
        if (fpsPlayer.GetComponent<BloodPickupScr>().bloodCollected)
        {
            secondsCount += Time.deltaTime;
            textControls.SetActive(true);

            if (secondsCount > 3)
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
