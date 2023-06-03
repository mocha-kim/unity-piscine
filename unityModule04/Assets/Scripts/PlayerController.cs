using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module04
{
    public class PlayerController : MonoBehaviour
    {
        private float _speed = 10.0f;
        private float _jumpPower = 20.0f;
    
        private Rigidbody2D _rigidbody;
    
        private bool _isJumping = false;
        private float _moveX;
    
        public bool IsJumping => _isJumping;
        public float MoveX => _moveX;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _moveX = Input.GetAxis("Horizontal");
        
            if (Input.GetButtonDown("Jump"))
            {
                if (_isJumping) return;
                _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                _isJumping = true;
            }
        }

        private void FixedUpdate()
        {
            if (_moveX == 0f) return;
            _rigidbody.velocity = new Vector2(_moveX * _speed, _rigidbody.velocity.y);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _isJumping = false;
            }
        }
    }
}