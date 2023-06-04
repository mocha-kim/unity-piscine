namespace Module04.StateMachine.Cactus
{
    public class CactusIdleState : State<Enemy>
    {
        public override void Update()
        {
            if (_context.DistToTarget <= _context.AttackRange)
            {
                _stateMachine.ChangeState<CactusAttackState>();
            }
        }
    }
}