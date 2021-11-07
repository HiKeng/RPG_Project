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

    [Header("References")]
    [SerializeField] float _baseAttackDamge = 2f;
    [SerializeField] float _upgradeModifier = 0.5f;

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

        GameObject _newAttack = Instantiate(_attackPrefab, _mousePosition._GetMousePosition(), Quaternion.identity);
        _newAttack.GetComponent<HarmTools>()._SetDamageToDeal(_calculateMagicDamage());

        _onAttack.Invoke();
    }

    float _calculateMagicDamage()
    {
        return _baseAttackDamge + GetComponent<PlayerSkillPoint>()._magicDamageUpgrade * _upgradeModifier;
    }
}
