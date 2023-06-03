using UnityEngine;

namespace Module04.StateMachine.Player
{
    public class PlayerDamagedState : State<Module04.Player>
    {
        private int _isDamagedId;

        public override void OnInit()
        {
            _isDamagedId = Animator.StringToHash("isDamaged");
        }

        public override void OnEnter()
        {
            _context.animator.SetBool(_isDamagedId, true);
            _stateMachine.ChangeState<PlayerIdleState>();
        }

        public override void Update()
        {}

        public override void OnExit()
        {
            _context.animator.SetBool(_isDamagedId, false);
        }
    }
}