using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] int _currentLevel = 1;

    [SerializeField] float _experienceBar = 50f;
    [SerializeField] float _currentExperienceProgress;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            _GetLevelProgress(100f);
        }

        _checkLevelUpProgress();
    }

    void _checkLevelUpProgress()
    {
        if(_currentExperienceProgress >= _experienceBar)
        {
            while (_currentExperienceProgress >= _experienceBar)
            {
                _currentExperienceProgress -= _experienceBar;
                _levelUp(1);
            }
        }
    }

    void _levelUp(int _levelUpAmount)
    {
        _currentLevel += _levelUpAmount;
    }

    public void _GetLevelProgress(float _amountToReceive)
    {
        _currentExperienceProgress += _amountToReceive;
    }
}
