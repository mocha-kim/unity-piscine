using System;
using Module04.StateMachine;
using Module04.StateMachine.Liana;
using UnityEngine;

namespace Module04
{
    public class Liana : Enemy
    {
        private GameObject _attackCollider;
        
        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine<Enemy>(this, new LianaIdleState());
            _stateMachine.AddState(new LianaAttackState());

            _attackCollider = transform.GetChild(0).gameObject;
        }

        public void OnAttackEventEnter()
        {
            _attackCollider.SetActive(true);
        }
        
        public void OnAttackEventExit()
        {
            _attackCollider.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Player>().OnDamaged(_damage);
            }
        }
    }
}