using Player.MovementSystem;
using Player.MovementSystem.States;
using UnityEngine;

public abstract class MovemenState
{
    protected readonly MovementStateMachine StateMachine;
    protected readonly MovementConfig Config;
    protected readonly Animator Animator;
    protected readonly float Speed;

    protected CharacterController CharacterController;

    // this parameters should be in the other script smth like BaseMovementState
    // to another states inherit it  from 
    private Vector3 _inputDirection;
    private float _currentVelocity;

    protected MovemenState(MovementStateMachine stateMachine, Animator animator, float speed, MovementConfig config,
        CharacterController characterController)
    {
        StateMachine = stateMachine;
        Animator = animator;
        Speed = speed;
        Config = config;
        CharacterController = characterController;
    }


    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    protected Vector3 GetInput()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        _inputDirection = new Vector3(horizontal,0f, vertical);
        return _inputDirection;
    }

    protected void Move(Vector3 direction)
    {
        CharacterController.Move(new Vector3(direction.x, 0f, direction.z) * (Speed * Time.deltaTime));
    }

    protected void Rotate()
    {
        if (_inputDirection.sqrMagnitude == 0)
            return;
            
        Transform transform = CharacterController.transform;
        float smoothTime = Config.SmoothTime;
        float angle = Mathf.Atan2(_inputDirection.x, _inputDirection.z) * Mathf.Rad2Deg;
        float targetAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref _currentVelocity, smoothTime);
        CharacterController.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    }

    protected void SetIdle()
    {
        StateMachine.SetState<IdleMovementState>();
    }
}