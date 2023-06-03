namespace Module04.StateMachine.Player
{
    public class PlayerRespawnState : State<Module04.Player>
    {
        public override void OnEnter()
        {
            _stateMachine.ChangeState<PlayerIdleState>();
        }

        public override void Update()
        {}
    }
}