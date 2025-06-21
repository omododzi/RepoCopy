using System;
using MovementSystem;
using PathCreation;
using RailsSystem;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private TrolleyController _trolleyController;
    private void Awake()
    {
        _movement.Initialize();
        _trolleyController.Initialize();
    }
}