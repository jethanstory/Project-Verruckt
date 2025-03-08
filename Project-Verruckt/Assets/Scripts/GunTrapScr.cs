using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunTrapScr : MonoBehaviour
{

    public GameObject loseCanvas;

    public bool playerShot = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if (other.gameObject.tag == "GunBoobyTrap") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            playerShot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        playerShot = false;

    }
}
