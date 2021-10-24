using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] Transform _targetToLookAt;

    void Update()
    {
        if(_targetToLookAt == null) { return; }

        gameObject.transform.LookAt(_targetToLookAt);
    }
}
