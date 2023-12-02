using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private bool reversed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 offset = other.transform.position - transform.position;
            if (reversed) other.transform.position = new Vector3(_target.position.x - offset.x, _target.position.y, _target.position.z-offset.z);
            else  other.transform.position = _target.position + offset;
        }
    }
}
