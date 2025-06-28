using UnityEngine;
using Random = UnityEngine.Random;

namespace General.Items
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "ScriptableObject/ItemConfig", order = 1)]
    public class ItemConfig : ScriptableObject
    {
        public GameObject Prefab => _prefab;
        public float Price => CalculatePrice();
        public ItemRarity Rarity => _rarity;
        public ItemMode Mode => _mode;

        [SerializeField] private GameObject _prefab;
        [SerializeField] private ItemRarity _rarity;
        [SerializeField,Range(10f,100f)] private float _priceMultiplier;
        [SerializeField] private ItemMode _mode;
        
        private float _price;
        
        private float CalculatePrice()
        {
            _price = Random.Range(_priceMultiplier * (int) _rarity,_priceMultiplier * (int)  _rarity);
            return _price;
        }
    }
}