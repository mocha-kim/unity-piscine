using Module04.StateMachine;
using UnityEngine;

namespace Module04
{
    public class Liana : MonoBehaviour
    {
        private StateMachine<Liana> _stateMachine;

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