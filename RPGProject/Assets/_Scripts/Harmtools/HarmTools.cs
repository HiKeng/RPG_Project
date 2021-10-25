using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmTools : MonoBehaviour
{
    [SerializeField] float _damageToDeal = 2f;
    [SerializeField] float _knockBackForce = 5f;

    public virtual void _DealDamage(GameObject _target)
    {
        _target.GetComponent<UnitHealth>()._TakeDamage(_damageToDeal);

        _KnockBack(_target.GetComponent<Rigidbody>());
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UnitHealth>() != null)
        {
            _DealDamage(other.gameObject);
        }
    }

    public virtual void _KnockBack(Rigidbody _target)
    {
        Vector3 _direction = transform.position - _target.position;

        _target.AddForce(_direction * _knockBackForce * -1);
    }

}
