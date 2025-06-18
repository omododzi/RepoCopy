using UnityEngine;

namespace MovementSystem.States
{
    public class IdleMovementState : MovemenState
    {
        private Vector2 _direction;
        
        public IdleMovementState(MovementStateMachine stateMachine, Animator animator, float speed, Rigidbody rigidbody) : base(stateMachine, animator, speed, rigidbody)
        {
        }

        public override void Enter()
        {
            Animator.SetBool("IsIdle",true);
        }

        public override void Update()
        {
            _direction = GetInput();
        }

        public override void FixedUpdate()
        {
            if (_direction.sqrMagnitude > 0 )
                StateMachine.SetState<WalkMovementState>();

            if (Input.GetKey(KeyCode.LeftShift))
                StateMachine.SetState<SlealthMovementState>();

            if (Input.GetKeyDown(KeyCode.Space))
                StateMachine.SetState<DashMovementState>();
        
        }

        public override void Exit()
        {
            Animator.SetBool("IsIdle",false);
        }
    }
}