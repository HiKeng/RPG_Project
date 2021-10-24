using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOffset : MonoBehaviour
{
    [SerializeField] bool _targetThisObject = true;
    [SerializeField] Vector3 _rotationOffset = new Vector3();



    void Start()
    {
        
    }

    void Update()
    {
        if(_targetThisObject)
        {
            transform.rotation = Quaternion.Euler(_rotationOffset);
        }
    }
}
