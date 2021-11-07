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
    public int _staminaUpgrade = 0;

    [Header("Events")]
    [SerializeField] UnityEvent _onOpenUI;
    [SerializeField] UnityEvent _onCloseUI;

    void Start()
    {
        
    }

    void Update()
    {
        _checkOpenSkillUpgradeUI();
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


    public void _updateCurrentCheckPoint(CheckPoint _checkPoint)
    {
        _currentCheckPoint = _checkPoint;
    }

    public void _upgradeStamina()
    {
        _staminaUpgrade++;
    }
}
