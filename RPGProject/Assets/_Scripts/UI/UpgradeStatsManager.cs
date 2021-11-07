using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeStatsManager : MonoBehaviour
{
    [SerializeField] TMP_Text _upgradePointText;
    [SerializeField] TMP_Text _upgradeStaminaText;
    [SerializeField] TMP_Text _upgradeMovementText;
    [SerializeField] TMP_Text _upgradeMagicDamageText;

    void Update()
    {
        _updateUpgradePointText();
        _updateStaminaUpgrade();
        _updateMovementUpgrade();
        _updateMagicDamageUpgrade();
    }

    void _updateUpgradePointText()
    {
        _upgradePointText.text = transform.root.GetComponent<PlayerSkillPoint>()._GetSkillPointAsString();
    }

    void _updateStaminaUpgrade()
    {
        _upgradeStaminaText.text = transform.root.GetComponent<PlayerSkillPoint>()._GetStaminaUpgrade().ToString();
    }

    void _updateMovementUpgrade()
    {
        _upgradeMovementText.text = transform.root.GetComponent<PlayerSkillPoint>()._movementUpgrade.ToString();
    }

    void _updateMagicDamageUpgrade()
    {
        _upgradeMagicDamageText.text = transform.root.GetComponent<PlayerSkillPoint>()._magicDamageUpgrade.ToString();
    }
}
