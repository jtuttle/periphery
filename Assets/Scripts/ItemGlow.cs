using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGlow : MonoBehaviour
{
    private GameObject _player;
    private GameObject _model;
    private float _glowThreshold = 4f;
    void Start()
    {
        _player = GameObject.Find("Player");
        _model = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        float distance = Vector3.Distance(_player.transform.position, gameObject.transform.position);
        float outline = (distance < _glowThreshold) ? 0.3f : 0;

        _model.GetComponent<Renderer>().material.SetFloat("_Outline", outline);
    }
}
