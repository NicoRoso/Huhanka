using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovementOlegVer : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] float _speed;
    [SerializeField] Transform _stabilizator;
    float x;
    float z;
    Vector3 move;
    Vector3 gravity;
    float fallSpeed = 0;
    public float gravityCoefficient = 1;
    void Update()
    {
        gravity = new Vector3(0, -fallSpeed, 0);
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        _stabilizator.eulerAngles = new Vector3(0, _stabilizator.eulerAngles.y, 0);
        move = _stabilizator.right * x + _stabilizator.forward * z + gravity;
        characterController.Move(move * _speed * Time.deltaTime);
    }
    float time = 0;
    private void FixedUpdate()
    {
        if (!characterController.isGrounded)
        {
            time += Time.deltaTime * gravityCoefficient * 9.8f;
            fallSpeed = time;
        }
        else
        {
            time = 0;
            fallSpeed = 0;
        }
    }
    public void SetGravityCoefficient(float newCoefficient)
    {
        gravityCoefficient = newCoefficient;
    }
}
