using UnityEngine;

namespace MovementSystem.States
{
    public class WalkMovementState : MovemenState
    {
        private Vector2 _inputDirection;

        public WalkMovementState(MovementStateMachine stateMachine, Animator animator, float speed, Rigidbody rigidbody) : base(stateMachine, animator, speed, rigidbody)
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
            _inputDirection = GetInput();
            if (_inputDirection.sqrMagnitude == 0)
            {
                StateMachine.SetState<IdleMovementState>();
            }
            Move(_inputDirection);
        }

        public override void Exit()
        {
            Animator.SetBool("IsWalking",false);
        }
    }
}