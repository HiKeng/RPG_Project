using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLight : MonoBehaviour
{
    void Update()
    {
        GetComponent<Light>().enabled = !DayNight_Manager.Instance._isDay;
    }
}
