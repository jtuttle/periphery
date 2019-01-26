using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDie : MonoBehaviour
{
    public Light spotLight;
    public GameObject RV;

    // Start is called before the first frame update
    void Start()
    {
        //float lightDist = transform.;
    }

    // Update is called once per frame
    void Update()
    {
        float radius = spotLight.GetComponent<LightRadius>().radius;
        float distance = Vector3.Distance(RV.transform.position, gameObject.transform.position);

        Debug.Log(distance > radius*.8393);
    }
}
