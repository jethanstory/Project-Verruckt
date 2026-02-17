using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClockCheck : MonoBehaviour
{
    public bool hasClock;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
