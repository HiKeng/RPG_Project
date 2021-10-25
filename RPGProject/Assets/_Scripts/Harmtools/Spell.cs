using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : HarmTools
{
    [SerializeField] float _lifeTime = 2f;
    float _currentLifeTime;

    private void Start()
    {
        _currentLifeTime = _lifeTime;
    }

    private void FixedUpdate()
    {
        if(_currentLifeTime > 0)
        {
            _currentLifeTime -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
