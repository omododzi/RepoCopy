using System;
using MovementSystem;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    private void Awake()
    {
        _movement.Initialize();
    }
}