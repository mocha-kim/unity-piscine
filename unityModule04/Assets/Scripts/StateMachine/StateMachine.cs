using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module04.StateMachine
{
    public class StateMachine<T>
    {
        private T _context;
    
        private State<T> _curState;
        private State<T> _preState;
        public State<T> CurrentState => _curState;
        public State<T> PreviousState => _preState;

        private Dictionary<Type, State<T>> _states = new Dictionary<Type, State<T>>();

        public StateMachine(T context, State<T> initState)
        {
            _context = context;

            AddState(initState);
            _curState = initState;
            _curState.OnEnter();
        }

        public void Update() => _curState.Update();
    
        public void AddState(State<T> state)
        {
            state.InitState(_context, this);
            _states[state.GetType()] = state;
        }

        public void ChangeState<State>() where State : State<T>
        {
            if (typeof(State) == _curState.GetType()) return;

            if (_curState != null)
            {
                _curState.OnExit();
            }
            _preState = _curState;
            _curState = _states[typeof(State)];
            _curState.OnEnter();
        }
    }

}