using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 8;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;

    private Rigidbody _rb;
    
    private bool _jumpInput;
    private bool _isGrounded;
    private bool _jumpInputReleased;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _jumpInput = Input.GetButtonDown("Jump");
        _jumpInputReleased = Input.GetButtonUp("Jump");
        
        Jump();
        
        JumpReleased();
    }

    private void Jump()
    {
        if (_jumpInput && _isGrounded)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, jumpHeight, _rb.velocity.z);
            _isGrounded = false;
        }
    }
    
    private void JumpReleased()
    {
        if (_jumpInputReleased && _rb.velocity.y > 0)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            _isGrounded = true;
        }
    }
}
