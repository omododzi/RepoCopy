using Player.FindingItemSystem;
using Player.FindingItemSystem.Inventory;
using Player.MovementSystem;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private FlashLight.FlashLight _flashLight;
        [SerializeField] private NightVisionGoggles _nightVision;

        public void Initialize()
        {
            _nightVision.Initialize();
            _flashLight.Initialize();
            _movement.Initialize();
            _inventory.Initialize();
        }
    }
}