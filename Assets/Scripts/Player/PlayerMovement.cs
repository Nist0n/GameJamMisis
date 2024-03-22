using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    protected Rigidbody rb;
    private Vector3 _vector3;
    private float _speed = 8;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _vector3.x = Input.GetAxis("Horizontal");
        _vector3.z = Input.GetAxis("Vertical");

        rb.MovePosition(rb.position + _vector3 * _speed * Time.deltaTime);
    }
}
