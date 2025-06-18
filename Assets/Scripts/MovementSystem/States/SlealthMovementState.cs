using UnityEngine;

namespace MovementSystem.States
{
    public class SlealthMovementState : MovemenState
    {
        public SlealthMovementState(MovementStateMachine stateMachine, Animator animator, float speed, Rigidbody rigidbody) : base(stateMachine, animator, speed, rigidbody)
        {
        }
    }
}