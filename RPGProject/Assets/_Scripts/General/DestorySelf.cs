using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySelf : MonoBehaviour
{
    [SerializeField] float _delayTime = 3f;
    void Start()
    {
        Destroy(gameObject, _delayTime);
    }
}
