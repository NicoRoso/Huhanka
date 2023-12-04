using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovementOlegVer : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] float _speed;
    [SerializeField] float _jumpHeigh;
    [SerializeField] float _maxFallspeed;
    [SerializeField] Transform _stabilizator;
    float x;
    float z;
    Vector3 move;
    Vector3 gravity;
    Vector3 jump = new Vector3(0,0,0);
    float fallSpeed = 0;
    public float gravityCoefficient = 1;
    bool isGrounded = true;
    private void Start()
    {
        StartCoroutine(isActuallyGrounded(0.15f));
    }
    void Update()
    {
        _stabilizator.rotation = transform.rotation;
        _stabilizator.rotation = new Quaternion(0, _stabilizator.rotation.y, 0, _stabilizator.rotation.w);
    }
    float time = 0;
    private void FixedUpdate()
    {
        gravity = new Vector3(0, -fallSpeed, 0);
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = _stabilizator.right * x + _stabilizator.forward * z + gravity + jump;
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        characterController.Move(move * _speed * Time.fixedDeltaTime);




        if (!characterController.isGrounded)
        {
            
            if(_maxFallspeed < Mathf.Abs(time))
            {
                if(gravityCoefficient < 0 && time > 0)
                {
                    time += Time.deltaTime * gravityCoefficient * 9.8f;
                    fallSpeed = time;
                }
                else
                {
                    if(gravityCoefficient > 0 && time < 0)
                    {
                        time += Time.deltaTime * gravityCoefficient * 9.8f;
                        fallSpeed = time;
                    }
                }
            }
            else
            {
                time += Time.deltaTime * gravityCoefficient * 9.8f;
                fallSpeed = time;
            }
        }
        else
        {
            time = 0;
            fallSpeed = 0;
        }
    }
    void Jump()
    {
        if (isGrounded)
        {
            StartCoroutine(JumpMaker());
        }
    }
    public void SetGravityCoefficient(float newCoefficient)
    {
        gravityCoefficient = newCoefficient;
    }
    IEnumerator isActuallyGrounded(float checkTime)
    {
        float timePassed = 0;
        while (true)
        {
            if(!characterController.isGrounded)
            {
                timePassed += Time.deltaTime;
            }
            else
            {
                isGrounded = true;
                timePassed = 0;
            }
            if (timePassed > checkTime)
            {
                isGrounded = false;
            }
            else
            {
                isGrounded = true;
            }
            yield return null;
        }
    }

    IEnumerator JumpMaker()
    {
        float heigh = _jumpHeigh;
        float time = 0;
        while(heigh > 0)
        {
            if ((isGrounded  || characterController.isGrounded) && time > 0.2f)
            {
                heigh = 0;
                break;
            }
            heigh -=  _jumpHeigh / 100 * Time.deltaTime;
            if(gravityCoefficient > 0)
            {
                jump = new Vector3(0, heigh, 0);
            }
            else
            {
                jump = Vector3.zero;
            }
            time += Time.deltaTime;
            yield return null;
        }
        jump = new Vector3(0, 0, 0);
        yield break;
    }
}
