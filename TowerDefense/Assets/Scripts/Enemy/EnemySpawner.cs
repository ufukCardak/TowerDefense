using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const int POOL_SIZE = 30;

    public Queue<GameObject> enemyPool;

    [Header("Spawn Variables")]
    [SerializeField] List<GameObject> enemyList;
    [SerializeField] Transform enemyStartPoint;
    [SerializeField] Transform enemyParent;
    [SerializeField] int[] wavesCount;
    [SerializeField] int currentWave;

    [SerializeField] float spawnDelay = 1f;
    [SerializeField] float spawnTimer = 10f;
    [SerializeField] int enemyCount;

    [SerializeField] private Factory[] factories;

    private Factory factory;


    private void Awake()
    {
  
    }

    private void Start()
    { 
        enemyPool = new Queue<GameObject>();

        for (int i = 0; i < POOL_SIZE; i++) 
        {
            /*GameObject enemy = Instantiate(enemyList[0],Vector3.zero,Quaternion.identity);
            enemy.SetActive(false);
            enemy.transform.parent = enemyParent;*/

            factory = factories[Random.Range(0, factories.Length)];

            GameObject enemy = factory.CreateEnemy();
            enemy.SetActive(false);
            enemy.transform.parent = enemyParent;

            enemyPool.Enqueue(enemy);
        }
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (enemyCount <= 1 && spawnTimer <= 0 && wavesCount.Length != currentWave)
        {
            enemyCount = wavesCount[currentWave];
            spawnTimer = 15f;
            StartCoroutine(SpawnEnemyies());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject enemy = GetEnemyFromPool();
            enemy.transform.position = enemyStartPoint.position;
        }
    }


    private GameObject GetEnemyFromPool()
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        return null;
    }

    public void EnqueuEnemyPool(GameObject enemy)
    {
        enemyPool.Enqueue(enemy);
    }
    public void SetEnemyCount(int enemyCount)
    {
        this.enemyCount = enemyCount;
    }

    IEnumerator SpawnEnemyies()
    {
        while (enemyCount <= wavesCount[currentWave] && enemyCount > 0)
        {
            GameObject enemy = GetEnemyFromPool();

            //GameObject enemy = Instantiate(enemyList[0], enemyStartPoint.position, Quaternion.identity);

            enemy.transform.position = enemyStartPoint.position;

            enemyCount--;

            yield return new WaitForSeconds(spawnDelay);
        }

        currentWave++;
    }
}
