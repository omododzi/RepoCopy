using UnityEngine;

namespace MovementSystem.States
{
    public class RunMovementState : MovemenState
    {
        private Vector2 _inpuDirection;

        public RunMovementState(MovementStateMachine stateMachine, Animator animator, float speed, Rigidbody rigidbody) : base(stateMachine, animator, speed, rigidbody)
        {
        }

        public override void Enter()
        {
            Animator.SetBool("IsRunning",true);
        }

        public override void Update()
        {
            _inpuDirection = GetInput();
            
        }

        public override void FixedUpdate()
        {
            if (_inpuDirection.sqrMagnitude == 0)
                StateMachine.SetState<IdleMovementState>();
            Move(_inpuDirection);
        }

        public override void Exit()
        {
            Animator.SetBool("IsRunning",false);
        }
    }
}