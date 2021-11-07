using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : UnitHealth
{
    [SerializeField] List<GameObject> _rewardList = new List<GameObject>();

    [SerializeField] float _expToGive = 10f;

    public void _SpawnReward()
    {
        for (int i = 0; i < _rewardList.Count; i++)
        {
            Instantiate(_rewardList[i], transform.position, Quaternion.identity);
        }
    }

    public void _GiveEXP()
    {
        Unit_Manager.Instance._player.GetComponent<PlayerLevel>()._ReceiveExperienceProgress(_expToGive);
        Debug.Log("Hello");
    }
}
