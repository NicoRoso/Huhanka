using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TeleportOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private bool reversed;
    [SerializeField] private bool gravityRotate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 offset = other.transform.position - transform.position;
            if (reversed)
                other.transform.position = _target.position - offset;
            else other.transform.position = _target.position + offset;
            if (gravityRotate) other.transform.localRotation = Quaternion.Euler(_target.transform.localRotation.x, _target.transform.localRotation.y,_target.transform.localRotation.z);
        }
    }
}
