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

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            _isPlayerEnter = true;

            other.GetComponent<PlayerSkillPoint>()._updateCurrentCheckPoint(this);

            _onPlayerEnter.Invoke();
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            _isPlayerEnter = false;

            other.GetComponent<PlayerSkillPoint>()._updateCurrentCheckPoint(null);

            _onPlayerExit.Invoke();
        }
    }
}
