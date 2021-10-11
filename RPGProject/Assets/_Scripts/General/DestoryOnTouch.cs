using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestoryOnTouch : MonoBehaviour
{
    [SerializeField] AudioSource _collectedSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            //_collectedSFX.Play();

            GameObject _newSFX = Instantiate(new GameObject(), transform.position, transform.rotation);

            _newSFX.AddComponent<AudioSource>();
            _newSFX.GetComponent<AudioSource>().clip = _collectedSFX.clip;
            _newSFX.GetComponent<AudioSource>().Play();
            Destroy(_newSFX, 2f);

            gameObject.SetActive(false);
        }
    }
}
