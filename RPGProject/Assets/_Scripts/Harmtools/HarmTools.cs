using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmTools : MonoBehaviour
{
    [SerializeField] float _damageToDeal = 2f;

    public virtual void _DealDamage(GameObject _target)
    {
        _target.GetComponent<UnitHealth>()._TakeDamage(_damageToDeal);

        
    }

    public T _GetUnitHealthType<T>(T _unitType)
    {
        return _unitType;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UnitHealth>() != null)
        {
            _DealDamage(other.gameObject);
        }
    }

}
