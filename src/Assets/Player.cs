using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _move;
    private Vector3 _gVelocity;
    private Vector2 _mouseInput;
    private float _xRotation = 0f;
    [SerializeField] private float _speed;
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private Transform _camera;

    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField]private bool _isGrounded;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundLayerMask);

        if (_isGrounded && _gVelocity.y < 0)
        {
            _gVelocity.y = -0.1f;
        }

        _move = transform.right* Input.GetAxis("Horizontal")+transform.forward* Input.GetAxis("Vertical");
        _characterController.Move(_move*_speed*Time.deltaTime);
        
        _mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        _xRotation -= _mouseInput.y*_mouseSensitivity*Time.deltaTime;
        _camera.localRotation = Quaternion.Euler(Math.Clamp(_xRotation, -90f, 90f), 0f, 0f);
        transform.Rotate(Vector3.up*_mouseInput.x*_mouseSensitivity*Time.deltaTime);
        
        _gVelocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_gVelocity * Time.deltaTime);
    }
}
