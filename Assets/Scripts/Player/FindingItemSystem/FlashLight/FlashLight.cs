using UnityEngine;
using UnityEngine.UI;

namespace Player.FlashLight
{
    public class FlashLight : MonoBehaviour
    {
        [SerializeField] private Button _flashlightButton;
        [SerializeField] private GameObject _flashLight;
        
        private bool _isFlashLightOff = true;

        public void Initialize()
        {
            _isFlashLightOff = true;
            _flashLight.SetActive(false);
            _flashlightButton.onClick.AddListener(FlashLightHadler);
        }
        
        private void FlashLightHadler()
        {
            if (_isFlashLightOff)
                _isFlashLightOff = false;
            else
                _isFlashLightOff = true;

            if (_isFlashLightOff)
                _flashLight.SetActive(false);
            else
                _flashLight.SetActive(true);
        }
    }
}