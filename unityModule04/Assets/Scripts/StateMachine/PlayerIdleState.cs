namespace Module04.StateMachine
{
    public class PlayerIdleState : State<Player>
    {
        public override void OnEnter()
        {
            if (_context.MoveX != 0f)
            {
                _stateMachine.ChangeState<PlayerMoveState>();
            }
        }

        public override void Update()
        {
            if (_context.IsJumping)
            {
                _stateMachine.ChangeState<PlayerJumpState>();
                return;
            }

            if (_context.MoveX != 0f)
            {
                _stateMachine.ChangeState<PlayerMoveState>();
                return;
            }
        }

        public override void FixedUpdate()
        {}
    }
}