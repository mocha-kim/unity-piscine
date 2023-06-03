using System.Collections;
using System.Collections.Generic;
using Module04.StateMachine;
using UnityEngine;

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
