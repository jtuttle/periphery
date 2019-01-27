using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComplete : MonoBehaviour
{
    public delegate void EventHandler();
    public event EventHandler DeathCompleteEvent;
    public void OnComplete() {
        if(this.DeathCompleteEvent != null) {
            DeathCompleteEvent();
        }
    }
}
