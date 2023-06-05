using UnityEngine;

namespace Module04.StateMachine.Player
{
    public class PlayerDamagedState : State<Module04.Player>
    {
        private int _damagedTriggerId;

        public override void OnInit()
        {
            _damagedTriggerId = Animator.StringToHash("damagedTrigger");
        }

        public override void OnEnter()
        {
            _context.PlayOneShot(EffectClip.Damaged);
            _context.animator.SetTrigger(_damagedTriggerId);
            _stateMachine.ChangeState<PlayerIdleState>();
        }

        public override void Update()
        {}

    }
}