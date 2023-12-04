using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheker : MonoBehaviour
{
    public bool IsGrounded;
    public LayerMask layerMask;

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, 0.2f, layerMask))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false; 
        }
    }
}
