using UnityEngine;

namespace StateMachine.Ghost
{
    public class GhostChaseState : State<Actor.Ghost>
    {
        private int _isWaitingId;
        private GameObject _target;

        private readonly float _chaseTime = 3f;
        private float _elapsedTime = 0f;

        public override void OnInit()
        {
            _isWaitingId = Animator.StringToHash("isWaiting");
            _target = GameObject.FindWithTag("Player");
        }

        public override void OnEnter()
        {
            _elapsedTime = 0f;
            _context.animator.SetBool(_isWaitingId, false);
        }

        public override void Update()
        {
            _context.navMeshAgent.SetDestination(_target.transform.position);
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime < _chaseTime)
                return;
            
            _stateMachine.ChangeState<GhostPatrolState>();
        }
    }
}