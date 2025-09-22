using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class PillEffectsExperimentalTransitionScr : MonoBehaviour
{
    public PostProcessVolume myPostProcess;
    public bool fadeOut;
    public bool fadeIn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
