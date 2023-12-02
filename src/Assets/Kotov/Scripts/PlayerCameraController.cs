using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterController : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    
    [SerializeField] private float _sensX, _sensY;
    [SerializeField] private float _xRotation, _yRotation;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sensY;

        _yRotation += mouseX;
        
        _xRotation -= mouseY;
        _xRotation = Math.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        orientation.localRotation = Quaternion.Euler(0, _yRotation, 0);
    }
}
