using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOffset : MonoBehaviour
{
    [SerializeField] bool _targetThisObject = true;
    [SerializeField] Vector3 _rotationOffset = new Vector3();

    [SerializeField] List<Transform> _targetList = new List<Transform>();

    void Start()
    {
        if (_targetThisObject)
        {
            _RotateObject(transform);
        }

        for (int i = 0; i < _targetList.Count; i++)
        {
            _RotateObject(_targetList[i]);
        }
    }

    public void _RotateObject(Transform _objectToRotate)
    {
        _objectToRotate.rotation = Quaternion.Euler(_rotationOffset);
    }
}
