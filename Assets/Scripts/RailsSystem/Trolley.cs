using System;
using MovementSystem;
using PathCreation;
using UnityEngine;

namespace RailsSystem
{
    public class Trolley
    {
        public event Action MovemenetStopped;
            
        public bool isEmpty => _isEmpty;

        private Transform _transform;
        private PathCreator _pathCreator;
        private float _distanceTravelled;
        
        private TrolleyConfig _config;
        private float _moveSpeed;
        private bool _isEmpty;
    
        public void Inilialize(PathCreator pathCreator,Transform transform)
        {
            _pathCreator = pathCreator;
            _transform = transform;
            _config = new TrolleyConfig();
            _isEmpty = true;
        }
        
        public void Move()
        {
            _distanceTravelled += _moveSpeed * Time.deltaTime;
            _transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled,EndOfPathInstruction.Stop);
            _transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled,EndOfPathInstruction.Stop);
        }

        public void SeatPlayer(Transform playerTransform)
        {
            _isEmpty = false;
            playerTransform.SetParent(_transform);
            playerTransform.localPosition = Vector3.zero;
        }
        
        public void GetOffPlayer(Transform playerTransform)
        {
            playerTransform.parent = null;
            _isEmpty = true;
        }

        public void StartMove()
        {
            float startMoveSpeed = _config.StartMoveSpeed;
            float targetMoveSpeed = _config.MaxMoveSpeed;
            _moveSpeed = Mathf.Lerp(startMoveSpeed,targetMoveSpeed,_config.AccelerationTime);
        }

        private void CheckMovement()
        {
            
        }
    }
}