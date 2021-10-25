using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour
{
    public float _maxHealth;
    
    float _currentHealth;

    [Header("Events")]
    [SerializeField] UnityEvent _onStart;
    [SerializeField] UnityEvent _onTakeDamage;
    [SerializeField] UnityEvent _onDead;

    public virtual void Start()
    {
        _currentHealth = _maxHealth;

        _onStart.Invoke();
    }

    public virtual void _TakeDamage(float _damageAmount)
    {
        _currentHealth -= _damageAmount;

        _onTakeDamage.Invoke();

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _Dead();
        }
    }

    public virtual void _Dead()
    {
        Debug.Log(name + " is dead");
        _onDead.Invoke();
        gameObject.SetActive(false);
    }
}
