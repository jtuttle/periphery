using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RV : MonoBehaviour
{
    public float MaxSpeed;

    public AudioClip EngineStart;
    public AudioSource EngineRunning;
    public AudioSource GameMusic;

    private float _speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(EngineStart, transform.position);
        StartCoroutine(DelayedRVStart());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x + _speed, pos.y, pos.z);
    }

    IEnumerator DelayedRVStart() {
        yield return new WaitForSeconds(2.8f);
        
        GameMusic.Play();
        EngineRunning.Play();
        
        StartCoroutine(StartRV(0.01f, 3f));
    }

    IEnumerator StartRV(float stepAmount, float duration) {
        float elapsed = 0;

        while(elapsed < duration) {
            _speed = Mathf.Lerp(0, MaxSpeed, elapsed / duration);
            elapsed += Time.deltaTime;

            yield return null;

            _speed = MaxSpeed;
        }
    }
}
