using System;
using UnityEngine;

namespace Module04
{
    public class PlayerController : MonoBehaviour
    {
        private bool _isJumping = false;
        private float _moveX;

        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider;
    
        public bool IsJumping => _isJumping;
        public float MoveX => _moveX;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            if (GameManager.Instance.IsGameOver)
                return;
            _moveX = Input.GetAxis("Horizontal");
            if (_moveX != 0f)
            {
                _spriteRenderer.flipX = _moveX < 0f;
            }
        
            if (Input.GetButtonDown("Jump"))
            {
                if (_isJumping) return;
                _isJumping = true;
            }
        }

        public void Init()
        {
            _spriteRenderer.flipX = false;
            _isJumping = false;
            _moveX = 0f;
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