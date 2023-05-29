using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float _speed = 3f;
    private Vector3 _dirVector = Vector3.zero;

    private bool _isGrounded = true;
    private readonly float _jumpHeight = 0.75f;
    private readonly float _gravity = -9.8f;
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrounded = _controller.isGrounded;
        if (_isGrounded && _dirVector.y < 0)
            _dirVector.y = 0;
        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move != Vector3.zero)
            transform.forward = move;
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _dirVector.y += Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y);
        }
        _dirVector.y += _gravity * Time.deltaTime;
        
        _controller.Move((_dirVector + move * _speed) * Time.deltaTime);
    }
}
