using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _attackPrefab;
    [SerializeField] Transform _spawnPosition;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Vector3 mousePos = Input.mousePosition;
            //mousePos.z = 2.0f;
            //Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

            //Debug.Log(objectPos);

            //Instantiate(_attackPrefab, objectPos, Quaternion.identity);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(_attackPrefab, hit.point, Quaternion.identity);
            }

            //GameObject _newBullet = Instantiate(_attackPrefab, _spawnPosition.position, Quaternion.identity);
        }
    }
}
