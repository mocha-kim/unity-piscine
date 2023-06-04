using Module04.StateMachine.Liana;
using UnityEngine;

namespace Module04.StateMachine.Cactus
{
    public class CactusAttackState : State<Enemy>
    {
        private float _elapsedTime = 0f;
        private float _attackDuration = 2.0f;
        private int _attackTriggerId;

        public override void OnInit()
        {
            _attackTriggerId = Animator.StringToHash("attackTrigger");
        }

        public override void OnEnter()
        {
            _context.animator.SetTrigger(_attackTriggerId);
        }

        public override void Update()
        {
            if (_context.DistToTarget > _context.AttackRange)
            {
                _stateMachine.ChangeState<CactusIdleState>();
                return;
            }

            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _attackDuration)
            {
                _elapsedTime = 0f;
                _context.animator.SetTrigger(_attackTriggerId);
            }
        }
    }
}