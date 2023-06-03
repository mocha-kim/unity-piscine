using UnityEngine;

namespace Module04.StateMachine.Player
{
    public class PlayerDeadState : State<Module04.Player>
    {
        private int _isDeadId;

        public override void OnInit()
        {
            _isDeadId = Animator.StringToHash("isDead");
        }

        public override void OnEnter()
        {
            _context.animator.SetBool(_isDeadId, true);
            _stateMachine.ChangeState<PlayerIdleState>();
        }

        public override void Update()
        {}

        public override void OnExit()
        {
            _context.animator.SetBool(_isDeadId, false);
        }
    }
}