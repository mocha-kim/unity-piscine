using Module04.StateMachine;
using UnityEngine;

namespace Module04
{
    public class Player : MonoBehaviour
    {
        private StateMachine<Player> _stateMachine;

        private void Awake()
        {
        }

        // Update is called once per frame
        void Update()
        {
            _stateMachine.Update();
        }
    }
}
