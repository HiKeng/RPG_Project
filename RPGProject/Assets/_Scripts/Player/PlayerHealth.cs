using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerStamina))]
public class PlayerHealth : UnitHealth
{
    PlayerStamina _playerStamina;

    private void Awake()
    {
        _playerStamina = GetComponent<PlayerStamina>();
    }

    public override void _TakeDamage(float _damageAmount)
    {
        _currentHealth -= _damageAmount;

        _onTakeDamage.Invoke();

        if(_currentHealth > 0) { return; }

        if (_playerStamina._GetCurrentStamina() > 0)
        {
            _ReplenishHealth();
        }
    }
}
