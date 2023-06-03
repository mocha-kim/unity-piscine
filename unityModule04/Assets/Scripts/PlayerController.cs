using UnityEngine;

namespace Module04
{
    public class PlayerController : MonoBehaviour
    {
        private bool _isJumping = false;
        private float _moveX;
    
        public bool IsJumping => _isJumping;
        public float MoveX => _moveX;

        private void Update()
        {
            _moveX = Input.GetAxis("Horizontal");
        
            if (Input.GetButtonDown("Jump"))
            {
                if (_isJumping) return;
                _isJumping = true;
            }
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