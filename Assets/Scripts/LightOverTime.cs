using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOverTime : MonoBehaviour
{

    float interval = .05f;
    float startAngle = 100;
    float currentAngle;

    Light lt;


    void Start()
    {
        lt = GetComponent<Light>();
        lt.type = LightType.Spot;
        currentAngle = startAngle;
    }

    void Update()
    {
        currentAngle -= interval;

        lt.spotAngle -= interval;

        if(lt.spotAngle < 0)
        {
            lt.spotAngle = 0;
        }
    }
}