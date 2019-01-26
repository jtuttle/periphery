using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientLight : MonoBehaviour
{
    void Start()
    {
        RenderSettings.ambientLight = Color.red;
    }
}