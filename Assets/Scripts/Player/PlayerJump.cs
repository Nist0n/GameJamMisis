using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerMovement
{
    [SerializeField] private float jumpHeight = 8;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    
    private bool _jumpInput;
    private bool _isGrounded;
    private bool _jumpInputReleased;
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
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
            _isGrounded = false;
        }
    }
    
    private void JumpReleased()
    {
        if (_jumpInputReleased && rb.velocity.y > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
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
