using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyFactory : Factory
{
    [SerializeField] private NormalEnemy normalEnemyPrefab;

    public override GameObject CreateEnemy()
    {
        GameObject normalEnemyInstance = Instantiate(normalEnemyPrefab.gameObject,Vector3.zero,Quaternion.identity);
        NormalEnemy newNormalEnemy = normalEnemyInstance.GetComponent<NormalEnemy>();

        newNormalEnemy.Initialize();

        return normalEnemyInstance;
    }

}
