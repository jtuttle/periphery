using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryMove : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("foo");

        if(other.gameObject.CompareTag("Player")) {
            gameObject.transform.parent = other.gameObject.transform;
        }
    }
 
}