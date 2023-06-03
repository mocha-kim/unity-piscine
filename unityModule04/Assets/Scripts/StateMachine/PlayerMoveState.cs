using UnityEngine;

namespace Module04.StateMachine
{
    public class PlayerMoveState : State<Player>
    {
        private int _moveXid;
        private float _speed = 10.0f;
        
        public override void OnInit()
        {
            _moveXid = Animator.StringToHash("moveX");
        }
        
        public override void OnEnter()
        {
            if (_context.MoveX == 0f)
            {
                _stateMachine.ChangeState<PlayerIdleState>();
            }
        }
        
        public override void Update()
        {
            if (_context.IsJumping)
            {
                _stateMachine.ChangeState<PlayerJumpState>();
                return;
            }
            if (_context.MoveX == 0f)
            {
                _stateMachine.ChangeState<PlayerIdleState>();
                return;
            }
            
            _context.animator.SetFloat(_moveXid, _context.MoveX);
        }

        public override void FixedUpdate()
        {
            _context.Rigidbody.velocity = new Vector2(_context.MoveX * _speed, _context.Rigidbody.velocity.y);
        }
    }
}