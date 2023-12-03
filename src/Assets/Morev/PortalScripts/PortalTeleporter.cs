using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTeleporter : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _reciever;
    bool playerIsOverlapping = false;
    void FixedUpdate()
    {
        if(playerIsOverlapping)
        {
            Vector3 portalToPlayer = _player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            if(dotProduct < 0)
            {
                CameraRotationSwitch(_reciever.rotation);
                _player.position = _reciever.position;






                playerIsOverlapping = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player.gameObject)
        {
            playerIsOverlapping = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player.gameObject)
        {
            playerIsOverlapping = false;
        }
    }

    void CameraRotationSwitch(Quaternion newRot)
    {
        _player.GetComponent<lookAround>().RotateCameraOnPortal(newRot);
    }
}
