using System;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateMachine 
{
    private MovemenState CurrentState { get; set; }
        
    private Dictionary<Type,MovemenState> _states = new Dictionary<Type, MovemenState>();

    public void AddState(MovemenState state)
    {
        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : MovemenState
    {
        var type = typeof(T);

        if (CurrentState != null && CurrentState.GetType() == type)
            return;

        if (_states.TryGetValue(type,out MovemenState movemenState))
        {
            CurrentState?.Exit();
            CurrentState = movemenState;
            CurrentState.Enter();
        }
    }

    public void Update()
    {
        CurrentState?.Update();
    }

    public void FixedUpdate()
    {
        CurrentState?.FixedUpdate();
        Debug.Log(CurrentState.GetType());
    }
}