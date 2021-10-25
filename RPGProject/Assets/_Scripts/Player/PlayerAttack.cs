using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MousePosition))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _attackPrefab;
    [SerializeField] Transform _spawnPosition;

    MousePosition _mousePosition;

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
    }
}
