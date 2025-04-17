using UnityEngine;
using System.Collections.Generic;

public class AimPivot : MonoBehaviour
{
    public List<GameObject> enemiesInRange = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !enemiesInRange.Contains(other.gameObject))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && enemiesInRange.Contains(other.gameObject))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }

    void LateUpdate()
    {
        enemiesInRange.RemoveAll(enemy => enemy == null);
    }
}