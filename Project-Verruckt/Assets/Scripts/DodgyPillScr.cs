using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class DodgyPillScr : MonoBehaviour
{
    public bool dodgyPillTaken = false;
    public float randChangeTime;
    public float randSetTime;

    public float inBetweenSwapTime;
    public float endPillTime;
    public GameObject dPillSound;

    public GameObject cinematicSound;
    public GameObject cinematicSoundFast;

    public GameObject otherObjects;
    public GameObject realObjects;
    public GameObject viewSource;
    public GameObject torchObject;
    GameObject ObjectIwantToDestroy;
    public GameObject harmlessHalluc;

    public GameObject fpsPlayer;

    public int dPillsCollected;
    public int maxDodgyPillsCollected;
    public int dPillsTotalTaken;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && dPillsCollected >= 1)
        {
            dodgyPillTaken = true;
        }


        if (dodgyPillTaken)
        {
            endPillTime += Time.deltaTime;
            inBetweenSwapTime += Time.deltaTime;
            torchObject.SetActive(false);
            randSetTime = Random.Range(0f, 1f);
            cinematicSound.SetActive(true);

            harmlessHalluc.SetActive(true);

            if (endPillTime < 30)
            {
                //if (inBetweenSwapTime < Random.Range(0f, 5f)) // 5
                if (inBetweenSwapTime < 5f) // 5
                {
                    InBetween();
                    cinematicSoundFast.SetActive(true);
                }
                else if (inBetweenSwapTime > 15 && inBetweenSwapTime < Random.Range(16f, 20f)) // 15, 20
                    InBetween();
                else if (inBetweenSwapTime > 14.95 && inBetweenSwapTime < 19.95f) // 5
                    cinematicSoundFast.SetActive(true);
                else if (inBetweenSwapTime > Random.Range(27f, 29f)) // 27
                    InBetween();
                else if (inBetweenSwapTime > 26.95 && inBetweenSwapTime < 28.95f) // 5
                    cinematicSoundFast.SetActive(true);
                else
                {
                    otherObjects.SetActive(true);
                    realObjects.SetActive(false);
                    viewSource.SetActive(true);
                    cinematicSoundFast.SetActive(false);
                    // cinematicSoundFast.SetActive(false);
                }
                // randChangeTime = Random.Range(0f, 1f);
                // if (randChangeTime > 0.5f)
                // {
                //     otherObjects.SetActive(true);
                //     realObjects.SetActive(false);
                //     viewSource.SetActive(true);
                //     //randChangeTime = Random.Range(0f, 0.26f);
                //     //randChangeTime = Random.Range(0f, 0.499f);
                // }
                // else if (randChangeTime < 0.5f)
                // {
                //     otherObjects.SetActive(false);
                //     realObjects.SetActive(true);
                //     viewSource.SetActive(false);
                //     //randChangeTime = Random.Range(0f, 0.7f);
                //     //randChangeTime = Random.Range(0f, 0.99f);
                // }
                // //randChangeTime = Random.Range(0f, 1f);
            }
            else
            {
                randChangeTime = 0;
                otherObjects.SetActive(false);
                realObjects.SetActive(true);
                viewSource.SetActive(false);
                dodgyPillTaken = false;
                cinematicSound.SetActive(false);
                cinematicSoundFast.SetActive(false);
                dPillsCollected -= 1;
                dPillsTotalTaken += 1;

                harmlessHalluc.SetActive(false);
            }

        }
        else
        {
            endPillTime = 0;
            inBetweenSwapTime = 0;
            if (!fpsPlayer.GetComponent<PickUpObject>().isViewing)
            {
                torchObject.SetActive(true);
            }
        }

    }

    private void InBetween() // flicking between the two time eras
    {
        // cinematicSoundFast.SetActive(true);
        randChangeTime = Random.Range(0f, 1f);
        randSetTime = Random.Range(0f, 1f);
        if (randChangeTime > 0.7f) // 0.5
        {
            otherObjects.SetActive(true);
            realObjects.SetActive(false);
            viewSource.SetActive(true);
            //randChangeTime = Random.Range(0f, 0.26f);
            //randChangeTime = Random.Range(0f, 0.499f);
        }
        else if (randChangeTime < 0.7f) // 0.5
        {
            otherObjects.SetActive(false);
            realObjects.SetActive(true);
            viewSource.SetActive(false);
            //randChangeTime = Random.Range(0f, 0.7f);
            //randChangeTime = Random.Range(0f, 0.99f);
        }
        //randChangeTime = Random.Range(0f, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DodgyPills")
        {
            ObjectIwantToDestroy = other.gameObject; //set the gameobject you collided with to one you can reference
            Destroy(ObjectIwantToDestroy);
            dPillsCollected += 1;
            dPillSound.SetActive(false);
            dPillSound.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    { }

}
