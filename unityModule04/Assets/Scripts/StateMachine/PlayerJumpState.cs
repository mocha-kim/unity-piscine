using UnityEngine;

namespace Module04.StateMachine
{
    public class PlayerJumpState : State<Player>
    {
        private int _isJumpingId;
        private readonly float _jumpPower = 20.0f;
        private readonly float _speed = 10.0f;

        public override void OnInit()
        {
            _isJumpingId = Animator.StringToHash("isJumping");
        }

        public override void OnEnter()
        {
            _context.Rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _context.animator.SetBool(_isJumpingId, true);
        }

        public override void Update()
        {
            if (!_context.IsJumping)
            {
                _stateMachine.ChangeState<PlayerIdleState>();
            }
        }

        public override void FixedUpdate()
        {
            _context.Rigidbody.velocity = new Vector2(_context.MoveX * _speed, _context.Rigidbody.velocity.y);
        }

        public override void OnExit()
        {
            _context.animator.SetBool(_isJumpingId, false);
        }
    }
}