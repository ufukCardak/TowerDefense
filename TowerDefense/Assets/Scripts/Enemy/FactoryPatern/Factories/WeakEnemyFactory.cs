using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemyFactory : Factory
{
    [SerializeField] private WeakEnemy weakEnemyPrefab;

    public override GameObject CreateEnemy()
    {
        GameObject weakEnemyInstance = Instantiate(weakEnemyPrefab.gameObject, Vector3.zero, Quaternion.identity);
        WeakEnemy newWeakEnemy = weakEnemyInstance.GetComponent<WeakEnemy>();

        newWeakEnemy.Initialize();

        return weakEnemyInstance;
    }

}
