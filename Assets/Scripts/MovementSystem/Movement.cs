using System;
using MovementSystem.States;
using UnityEngine;

namespace MovementSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;

        private MovementConfig _config;
        private MovementStateMachine _stateMachine;

        public void Initialize()
        {
            _config = new MovementConfig();
            _stateMachine = new MovementStateMachine();
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            
            //pzds potom pomenyuaem
            _stateMachine.AddState(new IdleMovementState(_stateMachine,_animator,_config.IdleSpeed,_rigidbody));
            _stateMachine.AddState(new WalkMovementState(_stateMachine,_animator, _config.WalkSpeed,_rigidbody));
            _stateMachine.AddState(new RunMovementState(_stateMachine,_animator,_config.RunSpeed,_rigidbody));
            _stateMachine.AddState(new DashMovementState(_stateMachine,_animator, _config.DashSpeed,_rigidbody));
            _stateMachine.AddState(new SlealthMovementState(_stateMachine,_animator,_config.StealthSpeed,_rigidbody));
            
            _stateMachine.SetState<IdleMovementState>();
        }


        private void Update()
        {
            _stateMachine?.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine?.FixedUpdate();
        }
    }
}