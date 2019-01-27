using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{
    public AudioSource spookySounds;
    public AudioSource whiteNoise;
    public AudioSource Music;
    public Light spotLight;
    public GameObject RV;
    float spookyCounter = 0;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        whiteNoise.volume = Vector3.Distance(RV.transform.position, gameObject.transform.position);
        spookyCounter += Time.deltaTime;
        if (spookyCounter > (1, 100, 100, 1, Vector3.Distance(RV.transform.position, gameObject.transform.position))
        {

        }


    }
}
