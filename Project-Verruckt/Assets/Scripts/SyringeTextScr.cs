using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeTextScr : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject fpsPlayer;

    //bool endTime;
    public float secondsCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        syringeText();
    }


    public void syringeText()
    {
        if (fpsPlayer.GetComponent<PickupSyringeScr>().syringeCollected){
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
