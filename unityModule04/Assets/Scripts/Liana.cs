using Module04.StateMachine;
using Module04.StateMachine.Liana;
using UnityEngine;

namespace Module04
{
    public class Liana : Enemy
    {
        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine<Enemy>(this, new LianaIdleState());
        }
    }
}