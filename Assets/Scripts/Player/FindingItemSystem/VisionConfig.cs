using UnityEngine;
using UnityEngine.Rendering;

namespace Player.FindingItemSystem
{
    [CreateAssetMenu(fileName = "VisionConfig", menuName = "ScriptablrObject/VisionConfig", order = 1)]
    public class VisionConfig : ScriptableObject
    {
        public Color NightVisionColor => _nightVisionColor;
        public Color FogColor => _fogColor;
        public Color SkyColor => _skyColor;
        public Color GroundColor => _groundColor;
        public AmbientMode AmbientMode => _ambientMode;
        public bool Fog => _fog;
        public float AmbientIntensity => _ambientIntensity;
        public float FogDensity => _fogDensity;

        [SerializeField] private Color _nightVisionColor;
        [SerializeField] private Color _fogColor;
        [SerializeField] private Color _skyColor;
        [SerializeField] private Color _groundColor;
        [SerializeField] private AmbientMode _ambientMode;
        [SerializeField] private bool _fog;
        [SerializeField] private float _ambientIntensity;
        [SerializeField] private float _fogDensity;
    }
}