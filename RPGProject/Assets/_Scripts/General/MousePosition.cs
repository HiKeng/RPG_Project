using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] Transform _mouseCursor;

    [SerializeField] LayerMask _layerMask;

    bool _isDetected = false;

    void Update()
    {
        _castRay();
    }

    void _castRay()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _layerMask))
        {
            _isDetected = true;
            _mouseCursor.position = raycastHit.point;
        }
        else
        {
            _isDetected = false;
        }
    }

    public Vector3 _GetMousePosition()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _layerMask);

        return raycastHit.point;
    }

    public bool _GetIsDectected()
    {
        return _isDetected;
    }
}
