using UnityEngine;

namespace Player.MovementSystem.States
{
    public class StealthMovementState : MovemenState
    {
        private Vector3 _inputDirection;
        
        public StealthMovementState(MovementStateMachine stateMachine, Animator animator, float speed, MovementConfig config, CharacterController characterController) : base(stateMachine, animator, speed, config, characterController)
        {
        }
        
        public override void Enter()
        {
            Animator.SetBool("IsStealthing" ,true);
        }
        
        public override void Update()
        {
            _inputDirection = GetInput();
          
        }

        public override void FixedUpdate()
        {
            if (_inputDirection.sqrMagnitude == 0)
                SetIdle();
            
            if (Input.GetKeyUp(KeyCode.LeftShift))
                StateMachine.SetState<WalkMovementState>();
            
            Move(_inputDirection);
            Rotate();
        }
        
        public override void Exit()
        {
            Animator.SetBool("IsStealthing" ,false);
        }
    }
}