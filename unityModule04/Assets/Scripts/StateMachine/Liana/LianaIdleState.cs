using UnityEngine;

namespace Module04.StateMachine.Liana
{
    public class LianaIdleState : State<Enemy>
    {
        public override void Update()
        {
            if (_context.DistToTarget <= _context.AttackRange)
            {
                _stateMachine.ChangeState<LianaAttackState>();
            }
        }
    }
}