using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedFollow : MonoBehaviour
{
    public GameObject Target;

    private float _zDiff;

    // Start is called before the first frame update
    void Start()
    {
        _zDiff = gameObject.transform.position.z - Target.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Target.transform.position.x;
        float z = Target.transform.position.z + _zDiff;

        gameObject.transform.position = new Vector3(x, gameObject.transform.position.y, z);

        gameObject.transform.LookAt(Target.transform);
    }
}
