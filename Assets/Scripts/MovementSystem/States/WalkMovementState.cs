using System;
using UnityEngine;

namespace MovementSystem.States
{
    public class WalkMovementState : MovemenState
    {
        private Vector3 _inputDirection;
        public WalkMovementState(MovementStateMachine stateMachine, Animator animator, float speed, MovementConfig config, CharacterController characterController) : base(stateMachine, animator, speed, config, characterController)
        {
        }
        public override void Enter()
        {
            Animator.SetBool("IsWalking",true);
            
        }

        public override void Update()
        { 
            _inputDirection = GetInput();
        }

        public override void FixedUpdate()
        {
            if (_inputDirection.sqrMagnitude == 0)
                SetIdle();
            
            if (Input.GetKey(KeyCode.LeftShift))
                StateMachine.SetState<StealthMovementState>();

            Move(_inputDirection);
            Rotate();
        }

        public override void Exit()
        {
            Animator.SetBool("IsWalking",false);
        }
    }
}