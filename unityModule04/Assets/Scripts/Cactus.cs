using Module04.StateMachine;
using UnityEngine;

namespace Module04
{
    public class Cactus : MonoBehaviour
    {
        private StateMachine<Cactus> _stateMachine;

        private void Awake()
        {
            // TODO: _stateMachine init;
        }

        void Update()
        {
            _stateMachine.Update();
        }
    }
}
