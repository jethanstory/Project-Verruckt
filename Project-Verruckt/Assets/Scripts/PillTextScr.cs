using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillTextScr : MonoBehaviour
{
    float secondsCount = 0;

    public GameObject textControls;
    public GameObject textGoal;

    public GameObject fpsPlayer;

    void Start()
    {

    }


    void Update()
    {
        checkPills();
    }

    void checkPills()
    {
        if (fpsPlayer.GetComponent<PickUpObject>().hasItem) // || fpsPlayer.GetComponent<DodgyPillScr>().dPillsCollected > 0)
        {
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
