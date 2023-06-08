using UnityEngine;

namespace StateMachine.Ghost
{
    public class GhostVictoryState : State<Actor.Ghost>
    {
        private int _victoryIndex;

        public override void OnInit()
        {
            _victoryIndex = Animator.StringToHash("victory");
        }

        public override void OnEnter()
        {
            _context.animator.SetTrigger(_victoryIndex);
        }

        public override void Update()
        {}
    }
}