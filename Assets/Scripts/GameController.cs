using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject EndingScreen;
    public GameObject Player;
    public GameObject RV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<LightDie>().IsDead) {
            Player.SetActive(false);
            RV.SetActive(false);
            EndingScreen.SetActive(true);
        }
    }
}
