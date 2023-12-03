using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementOlegVer : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] float _speed;
    float x;
    float z;
    Vector3 move;
    Vector3 gravity;
    private void Start()
    {
        gravity = new Vector3(0, -1, 0);
    }
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = (transform.right.normalized * x + transform.forward.normalized * z) + gravity;
        characterController.Move(move * _speed * Time.deltaTime);
    }
}
