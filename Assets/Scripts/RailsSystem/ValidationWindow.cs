using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace RailsSystem
{
    public class ValidationWindow : MonoBehaviour
    {
        public event Action QueryAccepted;
        
        public bool IsAccepted => _isAccepted;

        [SerializeField] private Button _acceptButton;
        [SerializeField] private Button _rejectButton;
        
        private bool _isAccepted;

        public void Initialize()
        {
            gameObject.SetActive(false);
            _acceptButton.onClick?.AddListener(AcceptQuery);
            _rejectButton.onClick?.AddListener(RejectQuery);
            _isAccepted = false;
        }

        private void AcceptQuery()
        {
            gameObject.SetActive(false);
            _isAccepted = true;
            QueryAccepted?.Invoke();
        }

        private void RejectQuery()
        {
            gameObject.SetActive(false);
            _isAccepted = false;
        }
    }
}