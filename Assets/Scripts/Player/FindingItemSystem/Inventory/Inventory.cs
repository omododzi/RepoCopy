using System.Collections.Generic;
using UnityEngine;

namespace Player.FindingItemSystem.Inventory
{
    public class Inventory : MonoBehaviour 
    {
        [SerializeField] private List<Slot> _slots;
        [SerializeField] private InventoryUI _inventoryUI;
        private Camera _camera;
        private Ray _ray;

        public void Initialize()
        {
            _inventoryUI.Initialize();
            _camera = Camera.main;
            
            foreach (var slot in _slots)
                slot.Initialize();
        }
    }
}