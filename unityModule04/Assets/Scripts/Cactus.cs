using Module04.StateMachine;
using Module04.StateMachine.Cactus;
using UnityEngine;

namespace Module04
{
    public class Cactus : Enemy
    {
        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine<Enemy>(this, new CactusIdleState());
        }
    }
}
