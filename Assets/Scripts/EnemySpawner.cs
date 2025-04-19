using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(1, 5)]
    [SerializeField] private float spawnIntervals;
    [SerializeField] private EnemyController enemyPrefab;
    [SerializeField] private float minOffsetY;
    [SerializeField] private float maxOffsetY;
    [SerializeField] private uint enemiesInPool;
    private List<EnemyController> enemyPool = new();

    public IEnumerator SpawnWithDelay(EntityDamagerDataSO data)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnIntervals);

            var positionY = Random.Range(minOffsetY, maxOffsetY);
            var enemy = enemyPool.FirstOrDefault(go => !go.gameObject.activeSelf);
            enemy.Initialize(data);
            enemy.transform.position = new Vector3(transform.position.x, positionY, 0);
            ActivateObject(enemy);
        }
    }

    public void Initialize()
    {
        for (uint i = 0; i <= enemiesInPool; i++)
        {
            var newEnemy = Instantiate(enemyPrefab, transform);
            DisableObject(newEnemy);
            enemyPool.Add(newEnemy);
        }
    }

    public void DisableObject(EnemyController entity)
    {
        entity.gameObject.SetActive(false);
    }
    public void ActivateObject(EnemyController entity)
    {
        entity.gameObject.SetActive(true);
    }
}