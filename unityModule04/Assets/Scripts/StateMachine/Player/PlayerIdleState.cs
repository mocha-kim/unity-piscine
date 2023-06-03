namespace Module04.StateMachine.Player
{
    public class PlayerIdleState : State<Module04.Player>
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
    }
}