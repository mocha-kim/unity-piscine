using System;
using System.Collections;
using StateMachine;
using StateMachine.Ghost;
using UnityEngine;
using UnityEngine.AI;

namespace Actor
{
    public class Ghost : MonoBehaviour
    {
        private StateMachine<Ghost> _stateMachine;
        
        private float _elapsedTime = 0f;
        [SerializeField] private float _startDuration = 0f;
        [SerializeField] private Vector3[] _patrolPoints;

        [NonSerialized] public NavMeshAgent navMeshAgent;
        public Animator animator;


        private void Awake()
        {
            _stateMachine = new StateMachine<Ghost>(this, new GhostIdleState());
            _stateMachine.AddState(new GhostPatrolState(_patrolPoints));
            _stateMachine.AddState(new GhostChaseState());
            _stateMachine.AddState(new GhostVictoryState());

            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            GameManager.Instance.OnAlertTarget += OnAlertTarget;
        }

        private void Update()
        {
            if (_elapsedTime <= _startDuration)
            {
                _elapsedTime += Time.deltaTime;
                return;
            }
            _stateMachine.Update();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _stateMachine.ChangeState<GhostChaseState>();
            }
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnAlertTarget -= OnAlertTarget;
        }

        private void OnAlertTarget() => _stateMachine.ChangeState<GhostChaseState>();
    }
}
