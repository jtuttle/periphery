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
        float height = Mathf.Abs(transform.position.z - Plane.transform.position.z);
        float angle = gameObject.GetComponent<Light>().spotAngle / 2;
        radius = Mathf.Tan(Mathf.Deg2Rad*angle)*height;
        Debug.Log("radius" + radius);
        Debug.Log("height" + height);
        Debug.Log("angle" + angle);
    }
}
