using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCharacterInternalDialogueScr : MonoBehaviour
{
    public float secondsCount = 0;
    public float secondsCountPast = 0;
    string sceneName;
    bool firstTime = true;
    public Text Txt;
    public GameObject dialogueBox;
    public GameObject fpsPlayer;


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }


    void Update()
    {
        if (sceneName == "ReceptionTestStartScene")
        {
            dialogueBox.SetActive(true);
            secondsCount += Time.deltaTime;
            if (secondsCount >= 4)
                Txt.text = "Hmm, I left my painkillers at home. Maybe they have some here."; // "Ron, \n \n Did you take my key? I can't find it anywhere. \n \n - Becky"
            if (secondsCount >= 9)
            {
                Txt.text = "";
                dialogueBox.SetActive(false);
            }


            if (firstTime && fpsPlayer.GetComponent<PickUpObject>().isViewing)
            {
                secondsCountPast += Time.deltaTime;
                Txt.text = "Oh God what is going on";
                if (secondsCountPast >= 3)
                    Txt.text = "";
                if (secondsCountPast >= 6)
                    Txt.text = "";
                if (secondsCountPast >= 9)
                    Txt.text = "";
                if (secondsCountPast >= 12)
                    Txt.text = "I shouldn't have taken those";
                if (secondsCountPast >= 15)
                    Txt.text = "";
                if (secondsCountPast >= 18)
                    Txt.text = "";
                if (secondsCountPast >= 21)
                {
                    Txt.text = "";
                    dialogueBox.SetActive(false);
                }
            }
            if (!firstTime && fpsPlayer.GetComponent<PickUpObject>().isViewing && secondsCountPast > 1)
            {
                secondsCountPast = 0;
                firstTime = false;
            }
            if (fpsPlayer.GetComponent<PauseMenuScr>().activeMenu || fpsPlayer.GetComponent<PickupNoteAdvScr>().activeCanvas)
            {
                dialogueBox.SetActive(false);
            }
            else if (!fpsPlayer.GetComponent<PauseMenuScr>().activeMenu || !fpsPlayer.GetComponent<PickupNoteAdvScr>().activeCanvas)
            {
                dialogueBox.SetActive(true);
            }
        }
    }
}
