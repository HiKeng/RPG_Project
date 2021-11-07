using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Campfire : CheckPoint
{
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.GetComponent<PlayerStamina>() != null)
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
