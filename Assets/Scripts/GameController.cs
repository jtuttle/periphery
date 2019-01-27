using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject VictoryScreen;
    public GameObject Player;
    public GameObject RV;
    public FixedFollow Camera;

    public float VictoryThreshold = 200.0f;

    private bool _gameOver = false;

    void Start(){

    }

    void Update()
    {
        if(_gameOver) {
            return;
        }

        if(RV.transform.position.x > VictoryThreshold) {
            _gameOver = true;
            Player.SetActive(false);
            RV.GetComponent<RV>().enabled = false;
            VictoryScreen.SetActive(true);
        }

        if(Player.GetComponent<LightDie>().IsDead) {
            _gameOver = true;

            Player.GetComponent<PlayerController>().enabled = false;
            RV.SetActive(false);

            GameObject playerModel = Player.transform.GetChild(0).gameObject;
            playerModel.GetComponent<DeathComplete>().DeathCompleteEvent += OnDeathComplete;
            playerModel.GetComponent<Animator>().SetBool("Dead", true);

            Camera.IsShaking = false;
        }
    }

    void OnDeathComplete() {
        Player.SetActive(false);
        GameOverScreen.SetActive(true);
    }
}
