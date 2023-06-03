using System;
using Module04.StateMachine;
using UnityEngine;

namespace Module04
{
    public class Player : MonoBehaviour
    {
        public Animator animator;
        
        private PlayerController _controller;
        private StateMachine<Player> _stateMachine;
        private Rigidbody2D _rigidbody;

        public bool IsJumping => _controller.IsJumping;
        public float MoveX => _controller.MoveX;
        public Rigidbody2D Rigidbody => _rigidbody;
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
            _controller = GetComponent<PlayerController>();
            _rigidbody = GetComponent<Rigidbody2D>();

            _stateMachine = new StateMachine<Player>(this, new PlayerIdleState());
            _stateMachine.AddState(new PlayerMoveState());
            _stateMachine.AddState(new PlayerJumpState());
        }

        // Update is called once per frame
        private void Update()
        {
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }
    }
}
