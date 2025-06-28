using RailsSystem;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GeneralLight _generalLight;
    [SerializeField] private Player.Player _player;
    [SerializeField] private TrolleyController _trolleyController;

    private void Awake()
    {
        _generalLight.Initialize();
       _player.Initialize();
       _trolleyController.Initialize();
    }
}