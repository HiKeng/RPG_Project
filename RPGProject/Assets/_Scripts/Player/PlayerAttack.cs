using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MousePosition))]
public class PlayerAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject _attackPrefab;
    MousePosition _mousePosition;


    [Header("Events")]
    [SerializeField] UnityEvent _onAttack;

    private void Awake()
    {
        _mousePosition = GetComponent<MousePosition>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _mousePosition._GetIsDectected())
        {
            _castSpell();
        }
    }

    void _castSpell()
    {
        Debug.Log("Cast Spell");

        Instantiate(_attackPrefab, _mousePosition._GetMousePosition(), Quaternion.identity);
        _onAttack.Invoke();
    }
}
