using System;
using System.Collections.Generic;
using Module04.StateMachine;
using Module04.StateMachine.Player;
using UnityEngine;

namespace Module04
{
    public class Player : MonoBehaviour
    {
        [NonSerialized] public Animator animator;
        
        private PlayerController _controller;
        private StateMachine<Player> _stateMachine;
        private Rigidbody2D _rigidbody;

        private AudioSource _audio;
        private AudioSource _stepAudio;
        [SerializeField] private AudioClip[] _clips;

        public bool IsJumping => _controller.IsJumping;
        public float MoveX => _controller.MoveX;
        public Rigidbody2D Rigidbody => _rigidbody;

        [SerializeField] private Vector3 _initPosition;
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
            _controller = GetComponent<PlayerController>();
            _rigidbody = GetComponent<Rigidbody2D>();

            _audio = GetComponents<AudioSource>()[0];
            _stepAudio = GetComponents<AudioSource>()[1];

            _stateMachine = new StateMachine<Player>(this, new PlayerIdleState());
            _stateMachine.AddState(new PlayerMoveState());
            _stateMachine.AddState(new PlayerJumpState());
            _stateMachine.AddState(new PlayerDamagedState());
            _stateMachine.AddState(new PlayerDeadState());
            _stateMachine.AddState(new PlayerRespawnState());
        }

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
            transform.position = _initPosition;
            animator.SetFloat("moveX", 0f);
            _controller.Init();
        }
        
        public void OnDamaged(int damage)
        {
            _rigidbody.velocity = Vector2.zero;
            _stateMachine.ChangeState<PlayerDamagedState>();
            GameManager.Instance.PlayerHP -= damage;
            if (GameManager.Instance.PlayerHP <= 0)
            {
                _stateMachine.ChangeState<PlayerDeadState>();
            }
        }

        public void PlayOneShot(EffectClip type) => _audio.PlayOneShot(_clips[(int)type]);
        public void PlayStepSound() => _stepAudio.Play();
        public void StopStepSound() => _stepAudio.Pause();
    }
}
