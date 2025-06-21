using UnityEngine;

namespace MovementSystem.States
{
    public class IdleMovementState : MovemenState
    {
        public IdleMovementState(MovementStateMachine stateMachine, Animator animator, float speed, MovementConfig config, CharacterController characterController) : base(stateMachine, animator, speed, config, characterController)
        {
        }

        public override void Enter()
        {
            Animator.SetBool("IsIdle",true);
        }

        public override void FixedUpdate()
        {
            if (Input.GetAxis("Horizontal") > 0f || Input.GetAxis("Vertical") > 0f)
                StateMachine.SetState<WalkMovementState>();

            if (Input.GetKey(KeyCode.LeftShift))
                StateMachine.SetState<StealthMovementState>();
            
            Rotate();
        }

        public override void Exit()
        {
            Animator.SetBool("IsIdle",false);
        }
    }
}