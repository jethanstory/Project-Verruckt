using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadLevelScr : MonoBehaviour
{
    float textTime = 0f;
    public GameObject loadingText;
    public GameObject loadingText2;

    public GameObject woodDoorOpen;
    public GameObject woodDoorClose;
    public bool checkEnd;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        checkEnd = false;
        //SceneManager.LoadScene("MainZone");
    }

    void Update()
    {
        textTime += Time.deltaTime;
        loadingText.SetActive(true);
        woodDoorOpen.SetActive(true);

        if (textTime > 3)
        {
            woodDoorClose.SetActive(true);
        }

        if (textTime > 5)
        {
            loadingText.SetActive(false);
            loadingText2.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            checkEnd = true;

        }

        if (checkEnd)
        {
            textTime = 0f;
            checkEnd = false;
        }

        // if (Input.anyKey)
        // {
        //     loadingText2.SetActive(false);
        //     loadingText.SetActive(false);
        //     //SceneManager.LoadScene("TestStartScene");
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }
    }
}
