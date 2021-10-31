using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPool : Campfire
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerThirstily>() != null)
        {
            other.GetComponent<PlayerThirstily>()._ReplenishResource();
            _onPlayerEnter.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerThirstily>() != null)
        {
            other.GetComponent<PlayerThirstily>()._ReplenishResource();
            _onPlayerEnter.Invoke();
        }
    }
}
