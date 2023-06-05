using UnityEngine;

namespace Module04.StateMachine.Player
{
    public class PlayerMoveState : State<Module04.Player>
    {
        private int _moveXid;
        private readonly float _speed = 10.0f;
        
        public override void OnInit()
        {
            _moveXid = Animator.StringToHash("moveX");
        }
        
        public override void OnEnter()
        {
            if (_context.MoveX == 0f)
            {
                _stateMachine.ChangeState<PlayerIdleState>();
                return;
            }
            _context.PlayStepSound();
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

        public override void OnExit()
        {
            _context.StopStepSound();
        }
    }
}