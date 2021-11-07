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
    public UnityEvent _onPlayerExit;

    private void Update()
    {
        _CheckPointUIActive();
    }

    void _CheckPointUIActive()
    {
        if(!_isPlayerEnter) { return; }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Active checkpoint UI");
        }
    }

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
        if (other.GetComponent<PlayerHealth>() != null)
        {
            _isPlayerEnter = false;
            _onPlayerExit.Invoke();
        }
    }
}
