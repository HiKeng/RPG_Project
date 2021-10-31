using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerStamina))]
public class FoodResource : MonoBehaviour
{
    #region Variables
    [Header("Resource Amount")]
    [SerializeField] float _maxAmount = 5;
    float _currentAmount = 5f;

    [Header("Consumption Speed")]
    [SerializeField] float _idleConsumeSpeed = 0.2f;
    [SerializeField] float _MoveConsumeSpeed = 0.5f;
    float _currentConsumeSpeed;

    [Header("Stamina Consumption")]
    [SerializeField] float _consumeStaminaInterval = 1f;
    [SerializeField] float _consumeStaminaSpeedMultiplier = 0.3f;
    float _currentStaminaInterval;

    [Header("References")]
    [SerializeField] Slider _slider;
    #endregion

    #region Private Methods

    void Start()
    {
        _ReplenishResource();

        _currentConsumeSpeed = _idleConsumeSpeed;
        _currentStaminaInterval = _consumeStaminaInterval;
    }

    void Update()
    {
        if(_currentAmount > 0)
        {
            _reduceResourceOverTime();
            _currentConsumeSpeed = _GetCurrentConsumeSpeedCondition();
        }

        _updateSliderUI();
        _consumeStaminaOnRunningOut();
        _checkResourceExceedThanLimited();
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

    void _consumeStaminaOnRunningOut()
    {
        if(_currentAmount > 0) { return; }

        if(_currentStaminaInterval > 0)
        {
            _currentStaminaInterval -= Time.deltaTime * _consumeStaminaSpeedMultiplier;
        }
        else
        {
            GetComponent<PlayerStamina>()._ReduceStaminaAmount(1);
            _currentStaminaInterval = _consumeStaminaInterval;
        }
    }

    void _updateSliderUI()
    {
        _slider.value = _currentAmount / _maxAmount;
    }

    void _checkResourceExceedThanLimited()
    {
        if(_currentAmount > _maxAmount)
        {
            _currentAmount = _maxAmount;
        }

        if(_currentAmount < 0)
        {
            _currentAmount = 0;
        }
    }

    #endregion

    #region Public Methods

    public void _ReplenishResource()
    {
        _currentAmount = _maxAmount;
    }

    public void _RestoreResource(float _amountToRestore)
    {
        _currentAmount += _amountToRestore;
    }

    #endregion
}
