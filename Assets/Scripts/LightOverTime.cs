using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOverTime : MonoBehaviour
{
    public float Interval = .05f;

    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
        lt.spotAngle -= Interval;

        if(lt.spotAngle < 0)
        {
            lt.spotAngle = 0;
        }
    }
}