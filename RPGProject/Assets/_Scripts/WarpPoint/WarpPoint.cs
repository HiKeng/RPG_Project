using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class WarpPoint : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] WarpPoint _positionToGo;
    [SerializeField] Transform _SpawnPoint;

    [Header("Events")]
    [SerializeField] UnityEvent _onWarp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Unit_Manager.Instance._player)
        {
            _warpToPosition();
        }
    }

    void _warpToPosition()
    {
        Unit_Manager.Instance._player.transform.position = _positionToGo._SpawnPoint.position;
    }
}
