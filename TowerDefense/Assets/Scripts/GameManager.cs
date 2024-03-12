using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] EnemySpawner enemySpawner;

    private void Awake()
    {
        if (Instance != null &&  Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void EnqueuEnemyPool(GameObject enemy)
    {
        enemySpawner.EnqueuEnemyPool(enemy);
    }
}
