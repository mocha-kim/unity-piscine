using System;
using Module04.StateMachine;
using Module04.StateMachine.Player;
using UnityEngine;

namespace Module04
{
    public class Player : MonoBehaviour
    {
        private int _hp;
        
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
            _stateMachine.AddState(new PlayerDamagedState());
            _stateMachine.AddState(new PlayerDeadState());
            _stateMachine.AddState(new PlayerRespawnState());
        }

        // Update is called once per frame
        private void Update()
        {
            _stateMachine.Update();
        }

        private void Start()
        {
            Init();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        public void Init()
        {
            transform.position = GameManager.Instance.PlayerInitPosition;
            _hp = GameManager.Instance.PlayerInitHP;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        
        public void OnDamaged(int damage)
        {
            _rigidbody.velocity = Vector2.zero;
            _stateMachine.ChangeState<PlayerDamagedState>();
            _hp -= damage;
            if (_hp <= 0)
            {
                _stateMachine.ChangeState<PlayerDeadState>();
            }
        }
    }
}
