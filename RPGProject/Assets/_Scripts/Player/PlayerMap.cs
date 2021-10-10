using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerMap : MonoBehaviour
{
    [SerializeField] Image _mapUI;

    [Header("Events")]
    [SerializeField] UnityEvent _onOpenMap;
    [SerializeField] UnityEvent _onCloseMap;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            _mapUI.gameObject.SetActive(true);
            _onOpenMap.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            _mapUI.gameObject.SetActive(false);
            _onCloseMap.Invoke();
        }
    }
}
