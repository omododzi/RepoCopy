using System.Collections;
using UnityEngine;

namespace MovementSystem.States
{
    public class DashMovementState : MovemenState
    {
        private Vector2 _inputDirection;
        

        public DashMovementState(MovementStateMachine stateMachine, Animator animator, float speed, Rigidbody rigidbody) : base(stateMachine, animator, speed, rigidbody)
        {
        }

        public override void Enter()
        {
            Animator.SetBool("IsDashing",true);
        }

        public override void Update()
        {
            _inputDirection = GetInput();
        }

        public override void FixedUpdate()
        {
            if (_inputDirection.sqrMagnitude == 0)
                StateMachine.SetState<IdleMovementState>();
            if (Input.GetKeyDown(KeyCode.E))
            {
               // start coutine  Dash(0.35f);
            }
        }

        private IEnumerator Dash(double dashTime)
        {
            float startTime = Time.time;
            
            while (Time.time < startTime + dashTime)
            {
                Move(_inputDirection);
            }

            yield return null;
        }

        public override void Exit()
        {
            Animator.SetBool("IsDashing",false);
        }
    }
}