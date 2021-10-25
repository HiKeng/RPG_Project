using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public float _maxHealth;
    
    float _currentHealth;

    public virtual void _TakeDamage(float _damageAmount)
    {
        _currentHealth -= _damageAmount;
    }

    public virtual void _Dead()
    {

    }
}
