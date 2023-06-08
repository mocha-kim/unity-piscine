using UnityEngine;

namespace StateMachine.Ghost
{
    public class GhostPatrolState : State<Actor.Ghost>
    {
        private int _isWaitingId;
        
        private int _pointIndex = 0;
        private readonly int _pointCount = 0;
        private readonly Vector3[] _patrolPoints;

        public GhostPatrolState(Vector3[] patrolPoints)
        {
            _patrolPoints = patrolPoints;
            _pointCount = _patrolPoints.Length;
        }

        public override void OnInit()
        {
            _isWaitingId = Animator.StringToHash("isWaiting");
        }

        public override void OnEnter()
        {
            _context.animator.SetBool(_isWaitingId, false);
            _context.navMeshAgent.SetDestination(_patrolPoints[_pointIndex]);
        }

        public override void Update()
        {
            if (_context.navMeshAgent.remainingDistance <= 0.5f)
            {
                _pointIndex = (_pointIndex + 1) % _pointCount;
                _stateMachine.ChangeState<GhostIdleState>();
            }
        }
    }
}