using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _slopeSpeed;
    [SerializeField] private float _groundDrag;
    [SerializeField] private float _airSpeed;
    [SerializeField] private float _airDrag;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private float _jumpAirMultiplier;
    [SerializeField] private bool _jumpReady;
    private float _horizontalInput, _verticalInput;
    private Vector3 _moveDirection;

    [Header("Key binds")] [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    
    [Header("Is Grounded")] 
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private bool _isGrounded;

    [Header("Slope Hadle")] 
    [SerializeField] private float _maxSlopeAnggle;   
    [SerializeField] private float _slopeDistance;
    private RaycastHit _slopeHit;

    [Header("Gravity")] 
    [SerializeField] private Vector3 _gravity;
    [SerializeField] private float _gravityMax;
    [SerializeField] private float _gravityForce;
    
    [Header("Offset")]
    [SerializeField] GameObject stepRayUpper;
    [SerializeField] GameObject stepRayLower;
    [SerializeField] private LayerMask _stairsLayer;
    [SerializeField] float stepHeight = 0.3f;
    [SerializeField] float _lowOfset = 0.1f;
    [SerializeField] float _upOfset = 0.2f;
    [SerializeField] float stepSmooth = 2f;
    
    [SerializeField] private Transform _orientation;
    private Rigidbody RB;


    private void Start()
    {
        _gravity = -transform.up * _gravityForce;
        _jumpReady = true;

        RB = GetComponent<Rigidbody>();
        RB.freezeRotation = true;
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundLayer)  || 
                      Physics.CheckSphere(_groundCheck.position, _groundDistance, _stairsLayer);

        InputHandler();
        SpeedControl();
        
        if (_isGrounded) RB.drag = _groundDrag;
        else RB.drag = _airDrag;
    }

    private void Jump()
    {
        RB.velocity = new Vector3(RB.velocity.x, RB.velocity.y/4f, RB.velocity.z);
        RB.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void JumpReset()
    {
        _jumpReady = true;
        
    }
    private void FixedUpdate()
    {
        Move();
        
        if (OnSlope())  _gravity = Vector3.zero;
        else if (TryStairsCast())  _gravity = Vector3.zero;
        else if (_isGrounded) _gravity = -transform.up;
        else _gravity += -transform.up * _gravityForce * Time.deltaTime;

        if (_gravity.magnitude > _gravityMax)
        {
            _gravity = _gravity.normalized* _gravityMax;
        }

        GravityImpliment();
        StepClimb();

        Debug.DrawRay(transform.position, RB.velocity, Color.green);
    }
    void StepClimb()
    {
        stepRayUpper.transform.position =
            stepRayLower.transform.position + transform.up * stepHeight;
        if (TryStairsCast())
            RB.position -= transform.up * -stepSmooth * Time.deltaTime;
    }

    bool TryStairsCast()
    {
        return 
            Caster(_orientation.forward) ||
            Caster(_orientation.forward + _orientation.right) ||
            Caster(_orientation.right) ||
            Caster(-_orientation.forward + _orientation.right);
    }

    bool Caster(Vector3 dir)
    {
        RaycastHit hitLower;
        if (Physics.Raycast(stepRayLower.transform.position, dir, out hitLower, _lowOfset,_stairsLayer))
        {   
            Debug.DrawRay(stepRayLower.transform.position, dir* _lowOfset, Color.blue);
            Debug.DrawRay(stepRayUpper.transform.position, dir* _upOfset, Color.red);
            RaycastHit hitUpper;
            if (!Physics.Raycast(stepRayUpper.transform.position, dir, out hitUpper, _upOfset, _stairsLayer))
            {            Debug.DrawRay(stepRayUpper.transform.position, dir* _upOfset, Color.green);
                return true;
            }
        }
        if (Physics.Raycast(stepRayLower.transform.position, -dir, out hitLower, _lowOfset, _stairsLayer))
        {            Debug.DrawRay(stepRayLower.transform.position, dir* _lowOfset, Color.blue);
            Debug.DrawRay(stepRayUpper.transform.position, dir* _upOfset, Color.red);
            RaycastHit hitUpper;
            if (!Physics.Raycast(stepRayUpper.transform.position, -dir, out hitUpper, _upOfset, _stairsLayer))
            {        Debug.DrawRay(stepRayUpper.transform.position, dir* _upOfset, Color.green);
                return true;
            }
        }
        return false;
    }

    private void GravityImpliment()
    {
        Debug.DrawRay(transform.position, _gravity, Color.red);
        RB.AddForce(_gravity, ForceMode.Force);
    }

    private void InputHandler()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        if (_isGrounded && _jumpReady && Input.GetKey(_jumpKey))
        {
            _jumpReady = false;
            Jump();
            Invoke(nameof(JumpReset), _jumpCooldown);
        }
    }

    private void Move()
    {
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;

        if (OnSlope())
        {
            RB.AddForce(GetSlopeMoveDir() * _slopeSpeed, ForceMode.Force);
        }
        
        else if (_isGrounded) RB.AddForce(_moveDirection.normalized * _moveSpeed, ForceMode.Force);
        else RB.AddForce(_moveDirection.normalized * _airSpeed*_jumpAirMultiplier, ForceMode.Force);
    }
    

    private void SpeedControl()
    {
        if (OnSlope())
        {
            if (RB.velocity.magnitude > _slopeSpeed) 
                RB.velocity = RB.velocity.normalized * _slopeSpeed;
            // RB.AddForce(-transform.up*0.5f, ForceMode.Force);
        }
        else
        {
            Vector3 flatVel = new Vector3(RB.velocity.x, RB.velocity.y/4f, RB.velocity.z);
            if (flatVel.magnitude > _moveSpeed && _isGrounded)
            {
                Vector3 limitSettedVel = flatVel.normalized * _moveSpeed;
                RB.velocity = limitSettedVel;
            }
        }
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(_groundCheck.position, -_groundCheck.up, out _slopeHit, _slopeDistance))
        {
            float angle = Vector3.Angle(transform.up, _slopeHit.normal);
            return angle < _maxSlopeAnggle && angle != 0;
        }
        return false;
    }

    private Vector3 GetSlopeMoveDir()
    {
        return Vector3.ProjectOnPlane(_moveDirection, _slopeHit.normal).normalized;
    }
    
}
