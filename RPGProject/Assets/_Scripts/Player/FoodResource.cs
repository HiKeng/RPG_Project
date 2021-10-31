using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
public class FoodResource : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Slider _slider;

    [Header("Parameter")]
    [SerializeField] float _maxAmount = 5;
    float _currentAmount = 5f;

    [SerializeField] float _idleConsumeSpeed = 0.2f;
    [SerializeField] float _MoveConsumeSpeed = 0.5f;
    float _currentConsumeSpeed;

    void Start()
    {
        _ReplenishResource();

        _currentConsumeSpeed = _idleConsumeSpeed;
    }

    void Update()
    {
        _reduceResourceOverTime();

        if(_currentAmount > 0)
        {
            _currentConsumeSpeed = _GetCurrentConsumeSpeedCondition();
        }
    }

    float _GetCurrentConsumeSpeedCondition()
    {
        float _consumeSpeed;

        if (GetComponent<PlayerMovement>()._IsMoving())
        {
            _consumeSpeed = _MoveConsumeSpeed;
        }
        else
        {
            _consumeSpeed = _idleConsumeSpeed;
        }

        return _consumeSpeed;
    }

    void _reduceResourceOverTime()
    {
        _currentAmount -= Time.deltaTime * _currentConsumeSpeed;
    }

    void _ReplenishResource()
    {
        _currentAmount = _maxAmount;
    }
}
