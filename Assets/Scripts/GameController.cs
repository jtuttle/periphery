using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject VictoryScreen;
    public GameObject Player;
    public GameObject RV;

    private float _victoryThreshold = 100.0f;

    private bool _gameOver = false;

    void Update()
    {
        if(_gameOver) {
            return;
        }

        if(RV.transform.position.x > _victoryThreshold) {
            _gameOver = true;
            Player.SetActive(false);
            RV.SetActive(false);
            VictoryScreen.SetActive(true);
        }

        if(Player.GetComponent<LightDie>().IsDead) {
            _gameOver = true;
            Player.SetActive(false);
            RV.SetActive(false);
            GameOverScreen.SetActive(true);
        }
    }
}
