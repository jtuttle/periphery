using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDie : MonoBehaviour
{
    public Light light;
    public GameObject RV;

    // Start is called before the first frame update
    void Start()
    {
        //float lightDist = transform.;
    }

    // Update is called once per frame
    void Update()
    {
        float radius = light.GetComponent<LightRadius>().radius;
        float distance = Vector3.Distance(RV.transform.position, gameObject.transform.position);

        Debug.Log(distance > radius);
    }
}
