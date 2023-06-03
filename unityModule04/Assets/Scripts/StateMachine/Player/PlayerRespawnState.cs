namespace Module04.StateMachine
{
    public class PlayerRespawnState : State<Player>
    {
        public override void OnEnter()
        {
            _stateMachine.ChangeState<PlayerIdleState>();
        }

        public override void Update()
        {}
    }
}