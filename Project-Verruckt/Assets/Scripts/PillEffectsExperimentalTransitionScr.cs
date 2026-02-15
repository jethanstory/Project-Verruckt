using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class PillEffectsExperimentalTransitionScr : MonoBehaviour
{
    public PostProcessVolume myPostProcess;
    public CanvasGroup myUIGroup;
    public GameObject pillEffectsCanvas;
    public bool fadeOut;
    public bool fadeIn;

    int timesRun = 0;

    public bool fadeOutTime;
    public bool fadeInTime;

    public float finalTime;

    public bool hasTimed = false;

    public GameObject fpsPlayer;



    void Start()
    {

    }


    void Update()
    {
        // OldTestTransition();
        if (fpsPlayer.GetComponent<PickUpObject>().isViewing)
        {
            finalTime += Time.deltaTime;
            pillEffectsCanvas.SetActive(true);
            ExperimentalCanvasTransition();
            hasTimed = true;
            timesRun += 1;
            if (finalTime > 28.5) // 28.5
            {
                fadeInTime = true;
                ExperimentalCanvasTransition();
            }
            if (finalTime > 29.99) // 28
            {
                pillEffectsCanvas.SetActive(false);
            }
        }

        // else if (!fpsPlayer.GetComponent<PickUpObject>().isViewing && hasTimed) // && fpsPlayer.GetComponent<PickUpObject>().hasTakenPillAtLeastOnce)
        // {
        //     // pillEffectsCanvas.SetActive(true);
        //     fadeInTime = true;
        //     ExperimentalCanvasTransition();
        // }



        // else if (hasTimed)
        // {
        //     // fadeInTime = true;
        //     // fadeOutTime = false;
        //     // ExperimentalCanvasTransition();
        //     if (myUIGroup.alpha < 1)
        //     {
        //         myUIGroup.alpha += Time.deltaTime;
        //         if (myUIGroup.alpha >= 1)
        //         {
        //             myUIGroup.alpha -= Time.deltaTime;
        //             if (myUIGroup.alpha == 0)
        //             {
        //                 fadeInTime = false;
        //                 // fadeInTime = true;
        //                 hasTimed = false;
        //                 pillEffectsCanvas.SetActive(false);
        //             }
        //         }
        //     }

        // }



        // ExperimentalCanvasTransition();




        // if (fadeIn)
        // {
        //     if (myUIGroup.alpha < 1)
        //     {
        //         myUIGroup.alpha += Time.deltaTime;
        //         if (myUIGroup.alpha >= 1)
        //         {
        //             fadeIn = false;
        //         }
        //     }
        // }
        // if (fadeOut)
        // {
        //     if (myUIGroup.alpha >= 0)
        //     {
        //         myUIGroup.alpha -= Time.deltaTime;
        //         if (myUIGroup.alpha == 0)
        //         {
        //             fadeOut = false;
        //         }
        //     }
        // }


        // if (fadeOut)
        // {
        //     if (myUIGroup.alpha >= 0)
        //     {
        //         myUIGroup.alpha -= Time.deltaTime;
        //         if (myUIGroup.alpha == 0)
        //         {
        //             myUIGroup.alpha += Time.deltaTime;
        //             if (myUIGroup.alpha >= 1)
        //             {
        //                 fadeOut = false;
        //             }
        //         }
        //     }
        // }
    }

    void OldTestTransition()
    {
        // pillEffectsCanvas.SetActive(true);
        if (fadeIn)
        {
            if (myPostProcess.weight < 1)
            {
                myPostProcess.weight += Time.deltaTime;
                if (myPostProcess.weight >= 1)
                {
                    fadeIn = false;
                }
            }
        }
        if (fadeOut)
        {
            if (myPostProcess.weight >= 0)
            {
                myPostProcess.weight -= Time.deltaTime;
                if (myPostProcess.weight == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

    void ExperimentalCanvasTransition()
    {
        // pillEffectsCanvas.SetActive(true);
        if (fadeInTime)
        {
            if (myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime;
                if (myUIGroup.alpha >= 1)
                {
                    fadeInTime = false;
                    fadeOutTime = true;
                    Debug.Log("Monkey");
                }
            }
        }
        if (fadeOutTime)
        {
            if (myUIGroup.alpha >= 0)
            {
                fadeInTime = false;
                myUIGroup.alpha -= Time.deltaTime;
                Debug.Log("Dunky");
                Debug.Log(myUIGroup.alpha);
                if (myUIGroup.alpha == 0)
                {
                    fadeOutTime = false;
                    Debug.Log("Funky");
                    // fadeInTime = true;
                    pillEffectsCanvas.SetActive(false);
                }
                // else if (timesRun > 0)
                // {
                //     pillEffectsCanvas.SetActive(false);
                // }
            }
        }
    }
}
