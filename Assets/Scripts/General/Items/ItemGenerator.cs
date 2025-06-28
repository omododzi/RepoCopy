using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace General.Items
{
    public class ItemGenerator : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints;
        private ItemConfig _itemConfig;

        public void GenerateItems()
        {
            var items = Resources.LoadAll<ItemConfig>("Prefabs/ItemConfigs");
            
            foreach (var spawnPoint in _spawnPoints)
            {
                foreach (var item in items)
                {
                    var prefab = Instantiate(item.Prefab, item.Prefab.transform.position, quaternion.identity);
                    prefab.transform.position = spawnPoint.transform.position;
                }
            }
        }
    }
}