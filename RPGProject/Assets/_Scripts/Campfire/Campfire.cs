using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerStamina>() != null)
        {
            other.GetComponent<PlayerStamina>()._ResetCurrentStaminaAmountLeft();
        }
    }
}
