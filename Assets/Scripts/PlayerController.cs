using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    private GameObject item;
    public GameObject spotLight;
    public GameObject RV;

    public AudioClip BatteryPickup;
    public AudioClip BatteryDropoff;

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
        
        Vector3 direction = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        bool isMoving = false;

        if(direction.magnitude > 0) {
            transform.forward = direction;
            isMoving = true;
        }

        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Running", isMoving);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("RV") && item != null)
        {
            ItemEnum itemType = item.gameObject.GetComponent<ItemType>().ItemEnum;

            if (itemType == ItemEnum.BATTERY)
            {
                spotLight.GetComponent<LightOverTime>().IncreaseLight();
                GameObject.Destroy(item);
                item = null;

                AudioSource.PlayClipAtPoint(BatteryDropoff, transform.position, 0.4f);
            }
            else if(itemType == ItemEnum.TIRE)
            {
                item.transform.parent = other.gameObject.transform;
                Vector3 pos = other.gameObject.transform.position;
                item.gameObject.transform.position = new Vector3(pos.x - 2, pos.y += 3, pos.z);
                item = null;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup") && item == null) {
            item = other.gameObject;

            item.transform.parent = gameObject.transform;

            item.transform.position = gameObject.transform.position;
            item.transform.localPosition = new Vector3(0, 0, 0.5f);
            
            ItemGlow itemGlow = item.GetComponent<ItemGlow>();
            itemGlow.SetGlow(0);
            itemGlow.enabled = false;

            item.GetComponent<Collider>().enabled = false;

            ItemEnum itemType = item.gameObject.GetComponent<ItemType>().ItemEnum;

            if(itemType == ItemEnum.BATTERY) {
                AudioSource.PlayClipAtPoint(BatteryPickup, transform.position, 0.4f);
            }
        }
    }
}