using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(1, 5)]
    [SerializeField] private float spawnIntervals;
    [SerializeField] private EnemyController enemyPrefab;
    [SerializeField] private float minOffsetY;
    [SerializeField] private float maxOffsetY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWithDelay(spawnIntervals));
    }

    IEnumerator SpawnWithDelay(float seconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);

            var position = Random.Range(minOffsetY, maxOffsetY);
            var newEnemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, position, 0), Quaternion.identity);
        }
    }
}
