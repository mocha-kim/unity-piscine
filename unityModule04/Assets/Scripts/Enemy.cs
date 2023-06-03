using Module04.StateMachine;
using UnityEngine;

namespace Module04
{
    public abstract class Enemy : MonoBehaviour
    {
        protected StateMachine<Enemy> _stateMachine;
        protected GameObject _target;

        public GameObject Target => _target;
        
        protected virtual void Awake()
        {
            _target = GameObject.FindWithTag("Player");
        }
        
        protected virtual void Update()
        {
            _stateMachine.Update();
        }
    }
}