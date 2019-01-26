using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryMove : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("foo");
        gameObject.transform.parent = Player.transform;
    }
 
}