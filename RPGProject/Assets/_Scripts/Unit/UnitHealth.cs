using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public float _maxHealth;
    
    float _currentHealth;

    public virtual void Start()
    {
        _currentHealth = _maxHealth;
    }

    public virtual void _TakeDamage(float _damageAmount)
    {
        _currentHealth -= _damageAmount;

        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            _Dead();
        }
    }

    public virtual void _Dead()
    {
        Debug.Log(name + " is dead");
        gameObject.SetActive(false);
    }
}
