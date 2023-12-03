using System.Collections;
using System.Collections.Generic;
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
    private void Start()
    {
        gravity = new Vector3(0, -1, 0);
    }
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        _stabilizator.eulerAngles = new Vector3(0, _stabilizator.eulerAngles.y, 0);
        move = _stabilizator.right * x + _stabilizator.forward * z + gravity;
        characterController.Move(move * _speed * Time.deltaTime);
    }
}
