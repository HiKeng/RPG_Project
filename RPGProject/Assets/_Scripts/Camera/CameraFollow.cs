using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _targetToFollow;
    [SerializeField] bool _isFollow = true;

    Vector3 _offsetDistance;

    void Start()
    {
        _offsetDistance = transform.position - _targetToFollow.position;
    }

    private void Update()
    {
        if(!_isFollow) { return; }

        transform.position = _targetToFollow.position + _offsetDistance;
    }
}
