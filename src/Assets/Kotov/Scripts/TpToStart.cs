using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TpToStart : MonoBehaviour
{
    [SerializeField] private Vector3 Start;
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = Start;
    }
}
