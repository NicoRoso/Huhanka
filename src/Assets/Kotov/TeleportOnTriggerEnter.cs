using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 offset = other.transform.position - transform.position;
            other.transform.position = _target.position + offset;
        }
    }
}
