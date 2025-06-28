using UnityEngine;

namespace Player.MovementSystem.States
{
    public class SeatMovementState : MovemenState
    {
        private Vector3 _inputDirection;
        public SeatMovementState(MovementStateMachine stateMachine, Animator animator, float speed, MovementConfig config, CharacterController characterController) : base(stateMachine, animator, speed, config, characterController)
        {
        }

        public override void Enter()
        {
            Animator.SetBool("IsSeating",false);
        }

        public override void Update()
        {
            _inputDirection = GetInput();
        }

        public override void FixedUpdate()
        {
            Rotate();
        }

        public override void Exit()
        {
            Animator.SetBool("IsSeating",false);
        }
    }
}