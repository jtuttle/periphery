using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBreaking : MonoBehaviour
{
    float timer = 1f;
    int counter = 1;
    bool breakCar;
    public Transform prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)

    {
        Debug.Log("Trigered");
        breakCar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Untriggered");
        breakCar = false;
    }
    void Update()
    {
        if(breakCar == true)
        {
            Debug.Log("BreakCar True");
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {

                GameObject part = gameObject.transform.Find("Part" + counter.ToString()).gameObject;
                GameObject.Destroy(part);

                if (counter == 3)
                {
                    Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
                    GameObject.Destroy(gameObject);
                }

                timer = 1;
                counter += 1;

            }
        }
    }
}
