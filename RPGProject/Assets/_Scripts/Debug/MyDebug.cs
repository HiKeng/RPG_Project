using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyDebug : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Vector3 _threshold;

    [SerializeField] GameObject _fogGroup;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
             SceneManager.LoadScene(Application.loadedLevel);
        }

        if(_player.position.y <= _threshold.y)
        {
            _player.position = _spawnPoint.position;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if(_fogGroup.active)
            {
                _fogGroup.SetActive(false);
            }
            else
            {
                _fogGroup.SetActive(true);
            }
        }
    }
}
