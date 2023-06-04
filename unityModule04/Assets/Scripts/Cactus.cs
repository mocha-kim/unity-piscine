using Module04.StateMachine;
using Module04.StateMachine.Cactus;
using Unity.Mathematics;
using UnityEngine;

namespace Module04
{
    public class Cactus : Enemy
    {
        [SerializeField] private GameObject jellyPrefab;
        
        private bool _isLookAtRightSide;
        private Vector3 _launchPosition;
        
        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine<Enemy>(this, new CactusIdleState());
            _stateMachine.AddState(new CactusAttackState());

            _isLookAtRightSide = GetComponent<SpriteRenderer>().flipX;
            _launchPosition = transform.GetChild(0).position;
        }

        public void OnAttackEvent()
        {
            PlayEffectSound(0);
            var jelly = Instantiate(jellyPrefab, _launchPosition, quaternion.identity, transform);
            jelly.GetComponent<Jelly>().Throw(_isLookAtRightSide);
        }
    }
}
