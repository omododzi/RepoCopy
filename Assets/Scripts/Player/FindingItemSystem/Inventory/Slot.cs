using UnityEngine;
using UnityEngine.UI;

namespace Player.FindingItemSystem.Inventory
{
    public class Slot : MonoBehaviour
    {
        public bool IsEmpty => _isEmpty;

        [SerializeField] private Image _image;
        [SerializeField] private Sprite _icon;

        private bool _isEmpty;

        public void Initialize()
        {
            _isEmpty = true;
        }
    }
}