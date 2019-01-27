using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDie : MonoBehaviour
{
    public Light spotLight;
    public GameObject RV;

    public float SecondsToLive;

    public AudioSource WarningSound;

    [HideInInspector]
    public bool IsDead;

    private float _secondsOutside;

    private const float EDGE_FACTOR = 0.8393f;

    void Update()
    {
        float edge = spotLight.GetComponent<LightRadius>().radius * EDGE_FACTOR;
        float distance = Vector3.Distance(RV.transform.position, gameObject.transform.position);

        if(distance > edge) {
            _secondsOutside += Time.deltaTime;
        } else {
            _secondsOutside = 0;

            if(WarningSound.isPlaying) {
                WarningSound.Stop();
            }
        }

        if(_secondsOutside >= 10 && !WarningSound.isPlaying) {
            WarningSound.Play();
        }

        IsDead = (_secondsOutside >= SecondsToLive);
    }
}
