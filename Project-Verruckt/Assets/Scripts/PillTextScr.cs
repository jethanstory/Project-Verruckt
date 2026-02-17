using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PillTextScr : MonoBehaviour
{
    float secondsCount = 0;

    public GameObject textControls;
    public GameObject textControlsDodgy;
    public GameObject textGoal;

    public GameObject fpsPlayer;
    string sceneName;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }


    void Update()
    {
        checkPills();
    }

    void checkPills()
    {
        if (fpsPlayer.GetComponent<PickUpObject>().hasItem && sceneName == "ReceptionTestStartScene") // || fpsPlayer.GetComponent<DodgyPillScr>().dPillsCollected > 0)
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
        else if (sceneName == "labSceneRedone" && fpsPlayer.GetComponent<DodgyPillScr>().dPillsCollected > 0)
        {
            secondsCount += Time.deltaTime;
            textControlsDodgy.SetActive(true);

            if (secondsCount > 5)
            {
                textControlsDodgy.SetActive(false);
                // textGoal.SetActive(true);
                // if (secondsCount > 10)
                // {
                //     textGoal.SetActive(false);
                // }
            }
        }
    }


}
