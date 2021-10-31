using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight_Manager : SingletonBase<DayNight_Manager>
{
    [SerializeField] bool _isDay = true;

    UnitLight[] _unitLights;

    private void Awake()
    {
        _unitLights = GameObject.FindObjectsOfType<UnitLight>();
    }

    private void Update()
    {
        if(_isDay)
        {
            _setActiveLight(false);
        }
        else
        {
            _setActiveLight(true);
        }
    }

    void _setActiveLight(bool _isActive)
    {
        for (int i = 0; i < _unitLights.Length; i++)
        {
            _unitLights[i].gameObject.SetActive(_isActive);
        }
    }
}
