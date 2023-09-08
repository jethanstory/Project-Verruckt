using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLightScr : MonoBehaviour
{
    private Vector3 rotation;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rotation = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
