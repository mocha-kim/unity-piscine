using UnityEngine;

namespace StateMachine.Ghost
{
    public class GhostIdleState : State<Actor.Ghost>
    {
        private int _isWaitingId;

        private float _elapsedTime = 0f;
        private readonly float _waitTime = 4f;

        public override void OnInit()
        {
            _isWaitingId = Animator.StringToHash("isWaiting");
        }

        public override void OnEnter()
        {
            _context.animator.SetBool(_isWaitingId, true);
        }

        public override void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _waitTime)
            {
                _elapsedTime = 0f;
                _stateMachine.ChangeState<GhostPatrolState>();
            }
        }

        public override void OnExit()
        {
            _context.animator.SetBool(_isWaitingId, false);
        }
    }
}