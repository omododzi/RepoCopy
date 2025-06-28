using System;
using Player.MovementSystem.States;
using RailsSystem;
using UnityEngine;

namespace Player.MovementSystem
{
    [RequireComponent(typeof(CharacterController),typeof(Animator))]
    public class Movement : MonoBehaviour
    {
        public event Action TrolleyFounded;

        [SerializeField] private TrolleyController _trolley;
        private CharacterController _characterController;
        private Animator _animator;

        private MovementConfig _config;
        private MovementStateMachine _stateMachine;
        private LayerMask _layerMask;

        public void Initialize()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            _config = new MovementConfig();
            _stateMachine = new MovementStateMachine();
            
            //pzds potom pomenyuaem
            _stateMachine.AddState(new IdleMovementState(_stateMachine,_animator,_config.IdleSpeed,_config,_characterController));
            _stateMachine.AddState(new WalkMovementState(_stateMachine,_animator,_config.WalkSpeed,_config,_characterController));
            _stateMachine.AddState(new StealthMovementState(_stateMachine,_animator,_config.StealthSpeed,_config,_characterController));
            _stateMachine.AddState(new SeatMovementState(_stateMachine,_animator,_config.IdleSpeed,_config,_characterController));

            _stateMachine.SetState<IdleMovementState>();
        }

        private void OnEnable()
        {
            _trolley.PlayerSeated += OnPlayerSeated;
            _trolley.MotionStopped += OnTrolleyStopped;
        }

       
        private void OnDisable()
        {
            _trolley.PlayerSeated -= OnPlayerSeated;
            _trolley.MotionStopped -= OnTrolleyStopped;

        }

        private void OnPlayerSeated()
        {
            _stateMachine.SetState<SeatMovementState>();
            Debug.Log("5");
        }
        
        private void OnTrolleyStopped()
        {
            _stateMachine.SetState<IdleMovementState>();
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out TrolleyController trolley))
            {
                TrolleyFounded?.Invoke();
                Debug.Log("1");
            }
        }
    }
}