using System;
using StateMachine;
using StateMachine.Skeleton;
using UnityEngine;

namespace Actor
{
    public class Skeleton : MonoBehaviour
    {
        private StateMachine<Skeleton> _stateMachine;

        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private GameObject _torch;
        private GameObject _torchLight;
        private float _range;

        public Animator animator;
        
        private void Awake()
        {
            _stateMachine = new StateMachine<Skeleton>(this, new SkeletonIdleState(_torch, _layerMask));
            _stateMachine.AddState(new SkeletonAlertState());
            
            _torchLight = _torch.transform.GetChild(0).gameObject;
            _range = _torchLight.GetComponent<Light>().range;
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}