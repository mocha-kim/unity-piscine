using UnityEngine;

namespace Module04.StateMachine
{
    public class PlayerJumpState : State<Player>
    {
        private float _jumpPower = 20.0f;
        
        public override void OnEnter()
        {
            _context.Rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }

        public override void Update()
        {
            if (!_context.IsJumping)
            {
                _stateMachine.ChangeState<PlayerIdleState>();
            }
        }

        public override void FixedUpdate()
        {}
    }
}