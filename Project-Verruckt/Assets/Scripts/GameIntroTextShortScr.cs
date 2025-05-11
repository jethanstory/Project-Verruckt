using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameIntroTextShortScr : MonoBehaviour
{
    float startTime = 0f;
    public GameObject introText;
    public GameObject introText2;
    //public GameObject loadingText;
    public bool checkEnd;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        checkEnd = false;
        //SceneManager.LoadScene("MainZone");
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        introText.SetActive(true);
        if (startTime > 7)
        {
            introText.SetActive(false);
            introText2.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            checkEnd = true;

        }

        if (checkEnd)
        {
            startTime = 0f;
            checkEnd = false;
        }

        if (Input.anyKey)
        {
            introText2.SetActive(false);
            introText.SetActive(false);
            //SceneManager.LoadScene("TestStartScene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
