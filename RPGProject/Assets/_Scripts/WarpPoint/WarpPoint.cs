using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SphereCollider))]
public class WarpPoint : MonoBehaviour
{
    [SerializeField] string _stageToGo;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Unit_Manager.Instance._player)
        {
            SceneManager.LoadScene(_stageToGo);
        }
    }
}
