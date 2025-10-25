using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOnLoadScr : MonoBehaviour
{
    public CanvasGroup myUIGroup;
    // private bool fadeIn;
    private bool fadeOut = true;

    // public void ShowUI()
    // {
    //     fadeIn = true;
    // }

    // public void HideUI()
    // {
    //     fadeOut = true;
    // }

    // Update is called once per frame
    void Update()
    {
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
        if (fadeOut)
        {
            if (myUIGroup.alpha >= 0)
            {
                myUIGroup.alpha -= Time.deltaTime;
                if (myUIGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
