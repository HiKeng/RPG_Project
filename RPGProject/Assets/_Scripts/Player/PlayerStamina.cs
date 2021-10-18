using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerStamina : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text _staminaUI;

    [Header("Parameter")]
    [SerializeField] int _maxStaminaAmount = 5;
    int _currentStaminaAmount = 5;

    [SerializeField] float _staminaPerPoint = 30f;
    float _currentStamina;

    [SerializeField] float _consumeSpeed = 1f;


    void Start()
    {
        _ReplenishStamina();
    }

    void Update()
    {
       if(GetComponent<PlayerMovement>()._IsMoving() && _currentStamina > 0)
        {
            _currentStamina -= Time.deltaTime * _consumeSpeed;
        }

       if(_currentStamina <= 0 && _currentStaminaAmount > 0)
        {
            _updateStaminaAmount();
        }

       if(_currentStaminaAmount > _maxStaminaAmount)
        {
            _currentStaminaAmount = _maxStaminaAmount;
            _updateStaminaUI();
        }
    }

    private void _updateStaminaAmount()
    {
        _currentStaminaAmount--;
        _resetCurrentStaminaPoint();
        _updateStaminaUI();
    }

    void _updateStaminaUI()
    {
        _staminaUI.text = $"Stamina : {_currentStaminaAmount} / {_maxStaminaAmount}";
    }

    void _resetCurrentStaminaPoint()
    {
        _currentStamina = _staminaPerPoint;
    }

    public void _ReplenishStamina()
    {
        _currentStaminaAmount = _maxStaminaAmount;
        _currentStamina = _staminaPerPoint;
        _updateStaminaUI();
    }

    public void _RecoverStamina(int _amountToRecover)
    {
        _currentStaminaAmount += _amountToRecover;
        _updateStaminaUI();
    }
}
