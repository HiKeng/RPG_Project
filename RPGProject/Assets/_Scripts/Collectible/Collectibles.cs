using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(AudioSource))]
public class Collectibles : MonoBehaviour
{
    [SerializeField] int _staminaRecoverAmount = 1;

    [SerializeField] AudioSource _collectedSFX;

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            GameObject _newSFX = new GameObject();

            _newSFX.AddComponent<AudioSource>();
            _newSFX.GetComponent<AudioSource>().clip = _collectedSFX.clip;
            _newSFX.GetComponent<AudioSource>().Play();
            Destroy(_newSFX, 2f);

            gameObject.SetActive(false);

            if (other.gameObject.GetComponent<PlayerStamina>() != null)
            {
                other.gameObject.GetComponent<PlayerStamina>()._RecoverStamina(_staminaRecoverAmount);
            }
        }
    }
}
