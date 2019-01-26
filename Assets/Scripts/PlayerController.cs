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
        float yPos = transform.position.y + (moveVertical * speed);

        transform.position = new Vector3(xPos, yPos, 0);
    }
}