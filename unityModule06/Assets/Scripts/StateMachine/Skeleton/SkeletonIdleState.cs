using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace StateMachine.Skeleton
{
    public class SkeletonIdleState : State<Actor.Skeleton>
    {
        private RaycastHit hit;
        
        private GameObject _torchLight;
        private readonly float _range;
        
        private readonly LayerMask _layerMask;

        public SkeletonIdleState(GameObject torch, LayerMask layerMask)
        {
            _torchLight = torch.transform.GetChild(0).gameObject;
            _range = _torchLight.GetComponent<Light>().range;
            _layerMask = layerMask;
        }

        public override void Update()
        {
            for (float angle = -20; angle <= 20; angle += 20)
            {
                var dir = Quaternion.AngleAxis(angle, _torchLight.transform.right) * _torchLight.transform.forward;
                if (Physics.Raycast(_torchLight.transform.position, dir, out hit, _range, _layerMask))
                {
                    _stateMachine.ChangeState<SkeletonAlertState>();
                    return;
                }
                Debug.DrawRay(_torchLight.transform.position, dir * _range, Color.red);
                dir = Quaternion.AngleAxis(angle, _torchLight.transform.up) * _torchLight.transform.forward;
                if (Physics.Raycast(_torchLight.transform.position, dir, out hit, _range, _layerMask))
                {
                    _stateMachine.ChangeState<SkeletonAlertState>();
                    return;
                }
                Debug.DrawRay(_torchLight.transform.position, dir * _range, Color.red);
            }
        }
    }
}