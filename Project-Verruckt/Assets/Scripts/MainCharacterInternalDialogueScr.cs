using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCharacterInternalDialogueScr : MonoBehaviour
{
    float secondsCount = 0;
    string sceneName;
    public Text Txt;
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
        }

    }
}
