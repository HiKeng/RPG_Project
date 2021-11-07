using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerSkillPoint : MonoBehaviour
{
    [Header("References")]
    public CheckPoint _currentCheckPoint;
    [SerializeField] Image _upgradeUI;

    [Header("Variables")]
    [SerializeField] int _currentSkillPoint = 0;
    public int _staminaUpgrade = 0;

    [Header("Events")]
    [SerializeField] UnityEvent _onOpenUI;
    [SerializeField] UnityEvent _onCloseUI;

    void Start()
    {
        _modifyStats();
    }

    void Update()
    {
        _checkOpenSkillUpgradeUI();

        _modifyStats();
    }

    void _checkOpenSkillUpgradeUI()
    {
        if(_currentCheckPoint != null) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_upgradeUI == null) { return; }

                _upgradeUI.gameObject.SetActive(!_upgradeUI.gameObject.activeSelf);

                _onOpenUI.Invoke();
            }
        }
        else
        {
            if (_upgradeUI == null) { return; }

            _upgradeUI.gameObject.SetActive(false);

            _onCloseUI.Invoke();
        }
    }

    void _modifyStats()
    {
        _modifyStamina();
    }

    void _modifyStamina()
    {
        GetComponent<PlayerStamina>()._SetMaxStamina(_staminaUpgrade);
    }

    public void _updateCurrentCheckPoint(CheckPoint _checkPoint)
    {
        _currentCheckPoint = _checkPoint;
    }

    public void _upgradeStamina()
    {
        if(_currentSkillPoint <= 0) { return; }

        _staminaUpgrade += 1;
        _currentSkillPoint--;

        Debug.Log("GEEE");
    }
}
