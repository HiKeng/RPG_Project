using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RemoveParent : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] UnityEvent _onStart;

    private void Start()
    {
        _onStart.Invoke();
    }

    public void _removeParent()
    {
        transform.parent = null;
    }

    public void _RemoveParentOnTarget(Transform _target)
    {
        _target.parent = null;
    }
}
