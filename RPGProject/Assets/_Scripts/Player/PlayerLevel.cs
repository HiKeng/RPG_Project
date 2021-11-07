using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] int _currentLevel = 1;

    [SerializeField] float _experienceBar = 50f;
    [SerializeField] float _currentExperienceProgress;

    [Header("Skill Point")]
    [SerializeField] int _skillPointPerLevel = 5;
    [SerializeField] int _currentSkillPoint;


    [Header("Events")]
    [SerializeField] UnityEvent _onGainExperience;
    [SerializeField] UnityEvent _onLevelUp;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            _ReceiveExperienceProgress(100f);
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
        _ReceiveSkillPoint();

        _onLevelUp.Invoke();
    }

    public void _ReceiveExperienceProgress(float _amountToReceive)
    {
        _currentExperienceProgress += _amountToReceive;

        _onGainExperience.Invoke();
    }

    public void _ReceiveSkillPoint()
    {
        _currentSkillPoint += _skillPointPerLevel;
    }
}
