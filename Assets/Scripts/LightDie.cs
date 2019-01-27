using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDie : MonoBehaviour
{
    public Light spotLight;
    public GameObject RV;
    public FixedFollow Camera;

    public float SecondsToLive;

    public AudioSource WarningSound;

    public AudioSource Music;

    [HideInInspector]
    public bool IsDead;

    private float _originalMusicVolume;
    private float _secondsOutside;

    private const float EDGE_FACTOR = 0.8393f;

    
    void Start() {
        _originalMusicVolume = Music.volume;
        Debug.Log(_originalMusicVolume);
    }

    void Update()
    {
        if(IsDead) { return; }

        float edge = spotLight.GetComponent<LightRadius>().radius * EDGE_FACTOR;
        float distance = Vector3.Distance(RV.transform.position, gameObject.transform.position);

        if(distance > edge) {
            _secondsOutside += Time.deltaTime;
        } else {
            _secondsOutside = 0;

            if(WarningSound.isPlaying) {
                WarningSound.Stop();
            }

            Music.volume = _originalMusicVolume;

            Camera.IsShaking = false;
        }

        if(_secondsOutside >= 10 && !WarningSound.isPlaying) {
            Music.volume = 0;
            WarningSound.Play();
        }

        if(_secondsOutside >= 15) {
            Camera.IsShaking = true;
        }

        IsDead = (_secondsOutside >= SecondsToLive);
    }
}
