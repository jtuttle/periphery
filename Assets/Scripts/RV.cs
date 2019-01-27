using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RV : MonoBehaviour
{
    public float speed;

    public AudioClip EngineStart;
    public AudioSource EngineRunning;

    private bool _moving = false;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(EngineStart, transform.position);
        StartCoroutine(DelayedRVStart());
    }

    // Update is called once per frame
    void Update()
    {
        if(_moving) {
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x + speed, pos.y, pos.z);
        }
    }

    IEnumerator DelayedRVStart() {
        yield return new WaitForSeconds(2.8f);
        
        EngineRunning.Play();
        _moving = true;
    }
}
