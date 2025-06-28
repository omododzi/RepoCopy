using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player.FindingItemSystem
{
    public class NightVisionGoggles : MonoBehaviour
    {
        public event Action NightVisionTurnedOn;
        public event Action NightVisionTurnedOff;
        
        [SerializeField] private Button _nightVisionButton;

        private bool _isTurnedOff;
        private Camera _camera;
        private Ray _ray;

        public void Initialize()
        {
            _camera = Camera.main;
            _isTurnedOff = true;
            _nightVisionButton.onClick.AddListener(NightVisionHandler);
        }

        private void NightVisionHandler()
        {
            if (_isTurnedOff)
            {
                _isTurnedOff = false;
                NightVisionTurnedOn?.Invoke();
            }
            else
            {
                _isTurnedOff = true;
                NightVisionTurnedOff?.Invoke();
            }
        }
    }
}