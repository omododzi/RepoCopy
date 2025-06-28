using System;
using PathCreation;
using UnityEngine;

namespace RailsSystem
{
    public class Trolley
    {
        public bool IsEmpty => _isEmpty;

        public bool IsStopped => _isStopped;

        private Transform _transform;
        private PathCreator _pathCreator;
        private float _distanceTravelled;
        
        private TrolleyConfig _config;
        private float _moveSpeed;
        private bool _isEmpty;
        private bool _isStopped;

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

        public bool StopMotion()
        {
            if (Math.Abs(_distanceTravelled - _pathCreator.path.length) <= 1f)
            {
                _moveSpeed = 0f;
                _isStopped = true;
            }

            return _isStopped;
        }

        public void SeatPlayer(Transform playerTransform)
        {
            _isEmpty = false;
            playerTransform.SetParent(_transform);
            playerTransform.localPosition = Vector3.zero;
        }
        
        public void GetOffPlayer(Transform playerTransform)
        {
            _isEmpty = true;
            playerTransform.parent = null;
        }

        public void StartMove()
        {
            float startMoveSpeed = _config.StartMoveSpeed;
            float targetMoveSpeed = _config.MaxMoveSpeed;
            _moveSpeed = Mathf.Lerp(startMoveSpeed,targetMoveSpeed,_config.AccelerationTime);
        }
    }
}