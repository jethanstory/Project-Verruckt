using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLightScr : MonoBehaviour
{
    private Vector3 rotation;
    public float speed;

    public bool isRandom;
    // Start is called before the first frame update
    void Start()
    {
        rotation = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RandomSpeed());

        transform.Rotate(rotation * speed * Time.deltaTime);
    }
    IEnumerator RandomSpeed()
    {
        if (isRandom)
        {
            //speed = Random.Range(0f, 100.0f);
            speed = 25f;
            yield return new WaitForSeconds(5);
            transform.Rotate(rotation * speed * Time.deltaTime);
            speed = 5f;
            yield return new WaitForSeconds(5);
            transform.Rotate(rotation * speed * Time.deltaTime);
            // speed = Random.Range(0f, 50f);
            // speed = 15;
            // yield return new WaitForSeconds(5);
            // transform.Rotate(rotation * speed * Time.deltaTime);
        }
    }
}
