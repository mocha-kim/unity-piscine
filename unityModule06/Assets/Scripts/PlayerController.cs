using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float _speed = 3f;
    private Vector3 _dirVector = Vector3.zero;
    private Vector3 _jumpVector = Vector3.zero;

    private bool _isGrounded = true;
    private readonly float _jumpHeight = 1.5f;
    private readonly float _gravity = -20f;
    private CharacterController _controller;
    
    private int _speedIndex;
    private Animator _animator;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        
        _speedIndex = Animator.StringToHash("Speed");
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isGrounded = _controller.isGrounded;
        if (_isGrounded && _dirVector.y < 0)
            _jumpVector.y = 0;
        
        _dirVector.x = Input.GetAxis("Horizontal");
        _dirVector.z = Input.GetAxis("Vertical");
        if (_dirVector != Vector3.zero)
            transform.forward = _dirVector;
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _jumpVector.y += Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y);
        }
        _jumpVector.y += _gravity * Time.deltaTime;
        
        _controller.Move((_jumpVector + _dirVector * _speed) * Time.deltaTime);
        _animator.SetFloat(_speedIndex, _dirVector.magnitude);
    }
}
