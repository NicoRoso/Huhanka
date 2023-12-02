using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _playerCamera;
    [SerializeField] Transform _reciever;
    bool playerIsOverlapping = false;
    Vector3 playerAndPlayerCamDifference;
    void FixedUpdate()
    {
        playerAndPlayerCamDifference = _player.position - _playerCamera.position;
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = _playerCamera.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            if (dotProduct < 0)
            {
                //здесь выполн€етс€ телепортаци€ при входе в портал (само изменение position и rotation)
                //reciever - объект камеры, котора€ отвечает за рендер изображени€ данного портала
                _playerCamera.rotation = _reciever.rotation;
                _player.position = _reciever.position + playerAndPlayerCamDifference;
                //


                playerIsOverlapping = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
