using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;

    void Start ()
    {
        
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float xPos = transform.position.x + (moveHorizontal * speed);
        float zPos = transform.position.z + (moveVertical * speed);

        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup")) {
            Vector3 pos = gameObject.transform.position;
            other.gameObject.transform.parent = gameObject.transform;
            other.gameObject.transform.position = new Vector3(pos.x, pos.y + 1, pos.z);
        }
    }
}