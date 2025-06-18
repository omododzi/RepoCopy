using MovementSystem.States;
using UnityEngine;

namespace MovementSystem
{
    public abstract class MovemenState
    {
        protected readonly MovementStateMachine StateMachine;
        protected readonly Animator Animator;
        protected readonly float Speed;
        protected readonly Rigidbody Rigidbody;
        
        public MovemenState(MovementStateMachine stateMachine,Animator animator,float speed ,Rigidbody rigidbody)
        {
            StateMachine = stateMachine;
            Animator = animator;
            Speed = speed;
            Rigidbody = rigidbody;
        }
        
        
        public virtual void Enter() {}
        public virtual void Exit() {}

        public virtual void Update()
        {
            Vector2 inputDirection = GetInput();
            if (inputDirection.sqrMagnitude == 0)
                StateMachine.SetState<IdleMovementState>();
            
            Move(inputDirection);
        }
        public virtual void FixedUpdate(){}

        protected Vector2 GetInput()
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            Vector2 direction = new Vector2(horizontal, vertical);
            return direction;
        }

        protected virtual void Move(Vector2 direction)
        {
            Rigidbody.MovePosition(new Vector3(direction.x,0f,direction.y) *  (Speed * Time.deltaTime));
        }
    }
}