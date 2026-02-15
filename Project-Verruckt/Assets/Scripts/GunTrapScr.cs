using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunTrapScr : MonoBehaviour
{

    public GameObject loseCanvas;

    public GameObject soundOn;

    public bool playerShot = false;


    void Start()
    {

    }


    void Update()
    {
        if (playerShot)
        {
            loseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            //SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GunBoobyTrap")
        {
            playerShot = true;
            soundOn.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        playerShot = false;

    }
}
