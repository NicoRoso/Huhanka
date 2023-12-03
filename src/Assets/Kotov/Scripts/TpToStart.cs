using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TpToStart : MonoBehaviour
{
    [SerializeField] private Vector3 Start = new Vector3(1904.25891f,-111.255997f,-1897.42932f);
    private void OnTriggerEnter(Collider collision)
    {
        collision.transform.position = Start;
    }
}
