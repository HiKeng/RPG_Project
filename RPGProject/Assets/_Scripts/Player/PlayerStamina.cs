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
    [SerializeField] int _baseMaxStaminaAmount = 5;
    [SerializeField] int _currentMaxStaminaAmount;
    int _currentStaminaAmount = 5;

    [SerializeField] float _staminaPerPoint = 30f;
    float _currentStamina;

    [SerializeField] float _consumeSpeed = 1f;


    void Start()
    {
        _ReplenishStamina();

        _currentMaxStaminaAmount = _baseMaxStaminaAmount;
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

       if(_currentStaminaAmount > _currentMaxStaminaAmount)
        {
            _currentStaminaAmount = _currentMaxStaminaAmount;
            _updateStaminaUI();
        }

        _checkStaminaAmountLeft();
    }

    private void _updateStaminaAmount()
    {
        _currentStaminaAmount--;
        _resetCurrentStaminaPoint();
        _updateStaminaUI();
    }

    void _updateStaminaUI()
    {
        _staminaUI.text = $"Stamina : {_currentStaminaAmount} / {_currentMaxStaminaAmount}";
    }

    void _resetCurrentStaminaPoint()
    {
        _currentStamina = _staminaPerPoint;
    }

    public void _ReplenishStamina()
    {
        _currentStaminaAmount = _currentMaxStaminaAmount;
        _currentStamina = _staminaPerPoint;
        _updateStaminaUI();
    }

    public void _RecoverStamina(int _amountToRecover)
    {
        _currentStaminaAmount += _amountToRecover;
        _updateStaminaUI();
    }

    public void _ReduceStaminaAmount(int _amountToReduce)
    {
        Debug.Log("Reduced");
        _currentStaminaAmount -= _amountToReduce;
        _updateStaminaUI();
    }

    public void _ReduceStamina(float _amountToReduce)
    {
        _currentStamina -= _amountToReduce;
        _updateStaminaUI();
    }

    public float _GetCurrentStamina()
    {
        return _currentStaminaAmount;
    }

    void _checkStaminaAmountLeft()
    {
        if(_currentStaminaAmount > 0) { return; }

        gameObject.SetActive(false);
    }

    public void _SetMaxStamina(int _amount)
    {
        _currentMaxStaminaAmount = _baseMaxStaminaAmount + _amount;
        _updateStaminaUI();
    }

}
