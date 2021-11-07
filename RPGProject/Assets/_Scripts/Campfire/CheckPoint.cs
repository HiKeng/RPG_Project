using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] bool _isPlayerEnter;

    [Header("Events")]
    public UnityEvent _onPlayerEnter;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            _isPlayerEnter = true;
            _onPlayerEnter.Invoke();
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        
    }
}
