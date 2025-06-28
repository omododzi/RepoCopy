using System;
using PathCreation;
using Player.MovementSystem;
using UnityEngine;

namespace RailsSystem
{
    public class TrolleyController : MonoBehaviour
    {
        public event Action MotionStopped;
        public event Action PlayerSeated;
        
        [SerializeField] private Movement _movement;
        [SerializeField] private PathCreator _pathCreator;
        [SerializeField] private TrolleyUI _trolleyUI;
        
        private Trolley _trolley;
        private bool _isValidationAccepted;

        public void Initialize()
        {
            _trolley = new Trolley();
            _trolley.Inilialize(_pathCreator,transform);
            _trolleyUI.Initialize();
            _isValidationAccepted = false;
        }

        private void OnEnable()
        {
            _movement.TrolleyFounded += OnGiveChoice;
            _trolleyUI.ValidationWindow.QueryAccepted += OnPlayerSeated;
        }


        private void OnDisable()
        {
            _movement.TrolleyFounded -= OnGiveChoice;
            _trolleyUI.ValidationWindow.QueryAccepted -= OnPlayerSeated;
        }
        
        private void OnPlayerSeated()
        {
            PlayerSeated?.Invoke();
            _isValidationAccepted = true;
        } 

        private void OnGiveChoice()
        {
            if (_trolley.IsEmpty)
            {
                _trolleyUI.ShowValidationWindow();
                Debug.Log("2");
            }
        }

        private void FixedUpdate()
        {
            if (_isValidationAccepted)
            {
                _trolley.SeatPlayer(_movement.transform);
                _trolley.StartMove();
            }
            
            _trolley.Move();
            
            if (_trolley.StopMotion())
            {
                _trolley.GetOffPlayer(_movement.transform);
                MotionStopped?.Invoke();
                Destroy(gameObject);
            }
        }
        
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Movement movement))
            {
                _trolleyUI.ShowValidationWindow();
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.TryGetComponent(out Movement movement))
            {
                _trolleyUI.HideValidationWindow();
            }
        }
    }
}