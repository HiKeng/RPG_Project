using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class UnitHealth : MonoBehaviour
{
    public float _maxHealth = 20f;
    
    public float _currentHealth;

    [Header("Events")]
    [SerializeField] public UnityEvent _onStart;
    [SerializeField] public UnityEvent _onTakeDamage;
    [SerializeField] public UnityEvent _onReplenishHealth;
    [SerializeField] public UnityEvent _onDead;

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

    public virtual void _ReplenishHealth()
    {
        _currentHealth = _maxHealth;
        _onReplenishHealth.Invoke();
    }
}
