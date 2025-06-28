using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

namespace RailsSystem
{
    public class TrolleyUI : MonoBehaviour
    {
        public ValidationWindow ValidationWindow => _validationWindow;
        
        [SerializeField] private ValidationWindow _validationWindow;

        public void Initialize()
        {
            _validationWindow.Initialize();
        }
        
        public void ShowValidationWindow()
        {
            _validationWindow.gameObject.SetActive(true);
        }

        public void HideValidationWindow()
        {
            _validationWindow.gameObject.SetActive(false);
        }
    }
}