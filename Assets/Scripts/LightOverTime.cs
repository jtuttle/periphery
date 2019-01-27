using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOverTime : MonoBehaviour
{
    public float Interval = .05f;
    public float MaxSpotAngle = 70f;

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

    public void IncreaseLight() {
        StartCoroutine(ExpandSpotlight(0.8f, 0.5f));
    }

    IEnumerator ExpandSpotlight(float stepAmount, float duration) {
        float elapsed = 0;

        while(elapsed < duration) {
            Light light = gameObject.GetComponent<Light>();
            light.spotAngle = Mathf.Min(light.spotAngle + stepAmount, MaxSpotAngle);
            
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}