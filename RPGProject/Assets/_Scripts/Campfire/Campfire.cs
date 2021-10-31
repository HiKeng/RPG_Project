using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Campfire : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] public UnityEvent _onPlayerEnter;

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerStamina>() != null)
        {
            other.GetComponent<PlayerStamina>()._ReplenishStamina();
            _onPlayerEnter.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerStamina>() != null)
        {
            other.GetComponent<PlayerStamina>()._ReplenishStamina();
            _onPlayerEnter.Invoke();
        }
    }
}
