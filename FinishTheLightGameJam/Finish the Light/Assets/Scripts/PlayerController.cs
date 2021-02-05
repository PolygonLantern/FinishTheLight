using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float groundRaycastDistance;
    [SerializeField] private float jumpForce;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    { 
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Allows the player to jump if we are grounded
    /// </summary>
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }
    
    /// <summary>
    /// Creates a raycast that will check if we can jump or not
    /// </summary>
    /// <returns></returns>
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundRaycastDistance);
    }

    void Move()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalAxis,0 ,verticalAxis) * speed * Time.fixedDeltaTime;

        Vector3 newPosition = _rigidbody.position + _rigidbody.transform.TransformDirection(movement);

        _rigidbody.MovePosition(newPosition);

    }
}
