using System;
using Player.FindingItemSystem;
using UnityEngine;

public  class GeneralLight : MonoBehaviour
{
    [SerializeField] private VisionConfig _nightVisionConfig;
    [SerializeField] private VisionConfig _defaultVisionConfig;
    [SerializeField] private NightVisionGoggles _nightVisionGoggles;

    public void Initialize()
    {
        TurnOffNightVision();
    }

    private void OnEnable()
    {
        _nightVisionGoggles.NightVisionTurnedOn += TurnOnNightVision;
        _nightVisionGoggles.NightVisionTurnedOff += TurnOffNightVision;
    }

    private void OnDisable()
    {
        _nightVisionGoggles.NightVisionTurnedOn -= TurnOnNightVision;
        _nightVisionGoggles.NightVisionTurnedOff -= TurnOffNightVision;
    }

    private void TurnOnNightVision()
    {
        RenderSettings.fog = _nightVisionConfig.Fog;
        RenderSettings.fogColor = _nightVisionConfig.FogColor;
        RenderSettings.ambientMode = _nightVisionConfig.AmbientMode;
        RenderSettings.ambientLight = _nightVisionConfig.NightVisionColor;
        RenderSettings.ambientIntensity = _nightVisionConfig.AmbientIntensity;
        RenderSettings.fogDensity = _nightVisionConfig.FogDensity;
        RenderSettings.ambientSkyColor = _nightVisionConfig.SkyColor;
        RenderSettings.ambientGroundColor = _nightVisionConfig.GroundColor;
    }
    
    private void TurnOffNightVision()
    {
        RenderSettings.fog = _defaultVisionConfig.Fog;
        RenderSettings.fogColor = _defaultVisionConfig.FogColor;
        RenderSettings.ambientMode = _defaultVisionConfig.AmbientMode;
        RenderSettings.ambientLight = _defaultVisionConfig.NightVisionColor;
        RenderSettings.ambientIntensity = _defaultVisionConfig.AmbientIntensity;
        RenderSettings.fogDensity = _defaultVisionConfig.FogDensity;
        RenderSettings.ambientSkyColor = _defaultVisionConfig.SkyColor;
        RenderSettings.ambientGroundColor = _defaultVisionConfig.GroundColor;
    }

    
}