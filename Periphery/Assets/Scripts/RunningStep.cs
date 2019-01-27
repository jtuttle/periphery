using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningStep : MonoBehaviour
{
    public AudioClip StepSound;

    public void OnStep()
    {
        AudioSource.PlayClipAtPoint(StepSound, transform.position, 0.5f);
    }
}
