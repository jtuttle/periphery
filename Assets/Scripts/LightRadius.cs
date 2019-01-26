using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRadius : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Plane;
    [HideInInspector]
    public float radius;

    // Update is called once per frame
    void Update()
    {
        float height = Mathf.Abs(transform.position.y - Plane.transform.position.y);
        float angle = Mathf.Deg2Rad * (gameObject.GetComponent<Light>().spotAngle / 2);
        radius = Mathf.Tan(angle) * height; 
    }
}
