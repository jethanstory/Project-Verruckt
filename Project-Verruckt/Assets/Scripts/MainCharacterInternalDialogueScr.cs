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
    public GameObject fpsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName == "ReceptionTestStartScene")
        {
            secondsCount += Time.deltaTime;
            if (secondsCount >= 4)
                Txt.text = "Ah shit, I left my painkillers at home. Maybe they have some here."; // "Ron, \n \n Did you take my key? I can't find it anywhere. \n \n - Becky"
            if (secondsCount >= 9)
                Txt.text = "";

            if (firstTime && fpsPlayer.GetComponent<PickUpObject>().isViewing)
            {
                secondsCountPast += Time.deltaTime;
                Txt.text = "HOLY FUCK WHAT IS GOING ON";
                if (secondsCountPast >= 3)
                    Txt.text = "";
                if (secondsCountPast >= 6)
                    Txt.text = "Fuck I shouldn't have taken those. oh god";
                if (secondsCountPast >= 9)
                    Txt.text = "";
                if (secondsCountPast >= 12)
                    Txt.text = "Oh shit man";
                if (secondsCountPast >= 15)
                    Txt.text = "";
                if (secondsCountPast >= 18)
                    Txt.text = "What the fuck";
                if (secondsCountPast >= 21)
                    Txt.text = "";
            }
            if (!firstTime && fpsPlayer.GetComponent<PickUpObject>().isViewing && secondsCountPast > 1)
            {
                secondsCountPast = 0;
                firstTime = false;
            }

        }

    }
}
