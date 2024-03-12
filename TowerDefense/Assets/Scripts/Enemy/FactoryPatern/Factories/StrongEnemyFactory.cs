using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemyFactory : Factory
{
    [SerializeField] private StrongEnemy StrongEnemyPrefab;

    public override GameObject CreateEnemy()
    {
        GameObject strongEnemyInstance = Instantiate(StrongEnemyPrefab.gameObject, Vector3.zero, Quaternion.identity);
        StrongEnemy newStrongEnemy = strongEnemyInstance.GetComponent<StrongEnemy>();

        newStrongEnemy.Initialize();

        return strongEnemyInstance;
    }

}
