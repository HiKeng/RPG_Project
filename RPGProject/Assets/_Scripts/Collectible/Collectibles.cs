using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectibles : MonoBehaviour
{
    [SerializeField] int _staminaRecoverAmount = 1;

    [SerializeField] AudioSource _collectedSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            GameObject _newSFX = new GameObject();

            _newSFX.AddComponent<AudioSource>();
            _newSFX.GetComponent<AudioSource>().clip = _collectedSFX.clip;
            _newSFX.GetComponent<AudioSource>().Play();
            Destroy(_newSFX, 2f);

            gameObject.SetActive(false);

            if(other.GetComponent<PlayerStamina>() != null)
            {
                other.GetComponent<PlayerStamina>()._RecoverStamina(_staminaRecoverAmount);
            }
        }
    }
}
