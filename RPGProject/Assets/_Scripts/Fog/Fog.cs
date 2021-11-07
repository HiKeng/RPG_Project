using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMap>() != null)
        {
            gameObject.SetActive(false);
        }

        if(other.CompareTag("PlayerMap"))
        {
            gameObject.SetActive(false);
        }
    }
}
