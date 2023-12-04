using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseScene : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _closingScene;
    [SerializeField] private GameObject _openingScene;
    [SerializeField] private float _distanceOfClosing;
    [SerializeField] private bool _playerOnScene = false;

    void Update()
    {
        if (Vector3.Distance(transform.position, _player.position) > _distanceOfClosing && _playerOnScene)
        {
            _closingScene.SetActive(false);
            if (_openingScene is not null) _openingScene.SetActive(true);
            gameObject.SetActive(false);
            _player.GetComponent<TimeDeath>().StartTimer(false, 120f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerOnScene = transform;
        }
    }
}
