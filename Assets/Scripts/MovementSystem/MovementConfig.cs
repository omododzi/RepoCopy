using System.Data;
using Unity.VisualScripting;

namespace MovementSystem
{
    public class MovementConfig
    {
        public readonly float SmoothTime = 0.05f;

        public readonly float IdleSpeed = 0f;
        public readonly float WalkSpeed = 3f;
        public readonly float RunSpeed = 15f;
        public readonly float StealthSpeed = 1.5f;
    }
}