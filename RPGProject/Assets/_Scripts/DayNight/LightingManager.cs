using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    #region Variables

    [Header("References")]
    [SerializeField] Light[] _directionalLights;
    [SerializeField] LightingPreset _preset;

    [Header("Variables")]
    [SerializeField, Range(0, 24)] float _timeOfDay;
    [SerializeField, Range(0, 24)] float _startingTime = 7f;
    [SerializeField] float _speedModifier = 1f;

    #endregion

    #region Methods

    private void Start()
    {
        _timeOfDay = _startingTime;
    }

    private void Update()
    {
        if(_preset == null) { return; }

        if(Application.isPlaying)
        {
            _timeOfDay += Time.deltaTime * _speedModifier;
            _timeOfDay %= 24; //Clamp between 0-24
            _UpdateLighting(_timeOfDay / 24f);
        }
        else
        {
            _UpdateLighting(_timeOfDay / 24f);
        }

        _updateDayNightBool();
    }

    void _UpdateLighting (float _timePrecent)
    {
        RenderSettings.ambientLight = _preset._AmbientColor.Evaluate(_timePrecent);
        RenderSettings.fogColor = _preset._FogColor.Evaluate(_timePrecent);

        if(_directionalLights != null)
        {
            for (int i = 0; i < _directionalLights.Length; i++)
            {
                _directionalLights[i].color = _preset._DirectionalColor.Evaluate(_timePrecent);
                _directionalLights[i].transform.localRotation = Quaternion.Euler(new Vector3((_timePrecent * 360f) - 90f, -170f, 0));
            }
        }
    }

    private void OnValidate()
    {
        Light[] lights = GameObject.FindObjectsOfType<Light>();

        foreach (Light light in lights)
        {
            if (light.type == LightType.Directional)
            {
                return;
            }
        }
    }

    void _updateDayNightBool()
    {
        if(_timeOfDay >= 6 && _timeOfDay < 18)
        {
            DayNight_Manager.Instance._isDay = true;
        }
        else
        {
            DayNight_Manager.Instance._isDay = false;
        }
    }

    #endregion
}
