using System.Collections;
using UnityEngine;

namespace StateMachine.Skeleton
{
    public class SkeletonAlertState : State<Actor.Skeleton>
    {
        private int _alertTargetId;

        private WaitForSeconds _duration = new WaitForSeconds(6f);

        public override void OnInit()
        {
            _alertTargetId = Animator.StringToHash("alertTarget");
        }

        public override void OnEnter()
        {
            Debug.Log("Alert");
            _context.animator.SetTrigger(_alertTargetId);
            _context.StartCoroutine(WaitDelay());
        }

        public override void Update()
        {}

        IEnumerator WaitDelay()
        {
            yield return _duration;
            _stateMachine.ChangeState<SkeletonIdleState>();
        }
    }
}