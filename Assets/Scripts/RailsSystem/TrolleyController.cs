using System;
using MovementSystem;
using PathCreation;
using UnityEngine;

namespace RailsSystem
{
    public class TrolleyController : MonoBehaviour
    {
        public event Action PlayerSeated;
        
        [SerializeField] private Movement _movement;
        [SerializeField] private PathCreator _pathCreator;
        [SerializeField] private TrolleyUI _trolleyUI;

        private Trolley _trolley;

        public void Initialize()
        {
            _trolley = new Trolley();
            _trolley.Inilialize(_pathCreator,transform);
            _trolleyUI.Initialize();
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
            _trolley.SeatPlayer(_movement.transform);
            PlayerSeated?.Invoke();
            Debug.Log("4");
            _trolley.StartMove();
        }

        private void OnGiveChoice()
        {
            if (_trolley.isEmpty)
            {
                _trolleyUI.GenerateValidationWindow();
                Debug.Log("2");
            }
        }

        private void FixedUpdate()
        {
            _trolley.Move();
        }
    }
}