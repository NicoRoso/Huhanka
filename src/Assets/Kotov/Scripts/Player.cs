using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform skin;
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
        Debug.DrawLine(_groundCheck.position+_groundCheck.transform.up*-1*_groundDistance, _groundCheck.position+_groundCheck.transform.up*_groundDistance);
        if (_isGrounded && _gVelocity.y < 0)
        {
            _gVelocity.y = -0.5f;
        }

        _move = transform.right* Input.GetAxis("Horizontal")+transform.forward* Input.GetAxis("Vertical");
        _characterController.Move(_move*_speed*Time.deltaTime);
        
        _mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        _xRotation -= _mouseInput.y*_mouseSensitivity*Time.deltaTime;
        _camera.localRotation = Quaternion.Euler(Math.Clamp(_xRotation, -90f, 90f), 0f, 0f);
        
        transform.Rotate(-skin.forward*_mouseInput.x*_mouseSensitivity*Time.deltaTime);
        Debug.DrawRay(skin.position, skin.up, Color.cyan);
        _gVelocity.y += _gravity * Time.deltaTime;
        _gVelocity = Vector3.ProjectOnPlane(_gVelocity, skin.forward);
        _characterController.Move(_gVelocity * Time.deltaTime);

    }
}
