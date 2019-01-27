using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedFollow : MonoBehaviour
{
    public GameObject Target;

    public float Damping = 1;
    public float ShakeAmount = 0.1f;

    public bool IsShaking = false;

    private float _zDiff;
    private Vector3 _up;

    void Start()
    {
        _zDiff = gameObject.transform.position.z - Target.transform.position.z;
        _up = transform.up;

        //gameObject.transform.LookAt(Target.transform);
    }

    void FixedUpdate()
    {
        Follow();
        LookAt();

        if(IsShaking) {
            Shake();
        }
    }

    private void Follow() {
        float x = Target.transform.position.x;
        float z = Target.transform.position.z + _zDiff;

        Vector3 desiredPosition = new Vector3(x, gameObject.transform.position.y, z);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, desiredPosition, Time.deltaTime * Damping);
    }

    private void LookAt() {
        Vector3 direction = Target.transform.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction, _up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * Damping);
    }

    private void Shake() {
        gameObject.transform.localPosition += Random.insideUnitSphere * ShakeAmount;
    }
}
