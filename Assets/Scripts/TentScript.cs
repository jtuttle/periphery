using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentScript : MonoBehaviour
{
    bool breakTent;
    public Transform prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("Trigered");
            breakTent = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Untriggered");
            breakTent = false;
        }
    }
    void Update()
    {
        if (breakTent == true)
        {
            Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}