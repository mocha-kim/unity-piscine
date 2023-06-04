using System;
using Module04.StateMachine;
using UnityEngine;

namespace Module04
{
    public abstract class Enemy : MonoBehaviour
    {
        protected StateMachine<Enemy> _stateMachine;
        protected GameObject _target;

        protected AudioSource _audio;
        [SerializeField] protected AudioClip[] _clips;
        
        [NonSerialized] public Animator animator;

        protected int _damage = 1;
        [SerializeField] protected float _attackRange;
        
        public GameObject Target => _target;
        public float AttackRange => _attackRange;
        public float DistToTarget => 
            Vector2.Distance(transform.position, _target.transform.position);

        protected virtual void Awake()
        {
            _target = GameObject.FindWithTag("Player");
            _audio = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
        }
        
        protected virtual void Update()
        {
            if (GameManager.Instance.IsGameOver)
                return;
            _stateMachine.Update();
        }

        public void PlayEffectSound(int index)
        {
            _audio.PlayOneShot(_clips[index]);
        }
    }
}