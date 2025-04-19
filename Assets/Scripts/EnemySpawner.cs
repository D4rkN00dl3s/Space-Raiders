using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(1, 5)]
    [SerializeField] private float spawnIntervals;
    [SerializeField] private EnemyController enemyPrefab;
    [SerializeField] private float minOffsetY;
    [SerializeField] private float maxOffsetY;

    public IEnumerator SpawnWithDelay(EntityDamagerDataSO data)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnIntervals);

            var position = Random.Range(minOffsetY, maxOffsetY);
            var newEnemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, position, 0), Quaternion.identity);
            newEnemy.Initialize(data);
        }
    }
}