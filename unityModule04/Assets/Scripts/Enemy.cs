using Module04.StateMachine;
using UnityEngine;

namespace Module04
{
    public abstract class Enemy : MonoBehaviour
    {
        protected StateMachine<Enemy> _stateMachine;
        protected GameObject _target;
        public Animator animator;

        protected int _damage = 1;
        [SerializeField] protected float _attackRange;
        
        public GameObject Target => _target;
        public float AttackRange => _attackRange;
        public float DistToTarget => 
            Vector2.Distance(transform.position, _target.transform.position);

        protected virtual void Awake()
        {
            _target = GameObject.FindWithTag("Player");
            animator = GetComponent<Animator>();
        }
        
        protected virtual void Update()
        {
            _stateMachine.Update();
        }
    }
}