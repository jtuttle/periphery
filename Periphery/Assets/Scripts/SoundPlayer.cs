using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource spookySounds;
    public List<AudioClip> spookyList;
    public AudioSource whiteNoise;
    public AudioSource Music;
    public GameObject RV;
    public float spookyCounter = 90;
    public float countMax;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(RV.transform.position, gameObject.transform.position);
        countMax = Vector3.Distance(RV.transform.position, gameObject.transform.position);
        if (dist > 100)
        {
            dist = 100;
        }

        if (countMax > 100)
        {
            countMax = 100;
        }

        whiteNoise.volume = dist/100;

        spookyCounter -= Time.deltaTime;
        if (spookyCounter < countMax && spookySounds.isPlaying == false)
        {
            spookySounds.volume = dist/2/100;
            spookySounds.clip = spookyList[Random.Range(1, spookyList.Count)];
            spookySounds.Play();
            spookyCounter = 100;
        }


    }
}