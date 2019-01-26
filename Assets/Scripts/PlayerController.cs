using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    private GameObject item;
    public GameObject spotLight;

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
        if(other.gameObject.CompareTag("Pickup") && item == null) {
            Vector3 pos = gameObject.transform.position;
            other.gameObject.transform.parent = gameObject.transform;
            other.gameObject.transform.position = new Vector3(pos.x, pos.y + 1, pos.z);
            item = other.gameObject;

            ItemEnum itemType = other.gameObject.GetComponent<ItemType>().ItemEnum;

            if(itemType == ItemEnum.BATTERY) {
                Debug.Log("BATTERY!");
            }
        }

        if(other.gameObject.CompareTag("RV"))
        {
            GameObject.Destroy(item);
            item = null;
            
            StartCoroutine(ExpandSpotlight(0.8f, 0.5f));
        }
    }

    IEnumerator ExpandSpotlight(float stepAmount, float duration) {
        float elapsed = 0;

        while(elapsed < duration) {
            spotLight.GetComponent<Light>().spotAngle += stepAmount;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}