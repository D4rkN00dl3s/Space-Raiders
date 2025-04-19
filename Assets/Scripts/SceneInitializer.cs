using System;
using UnityEngine;

public class SceneInitializer : MonoBehaviour

{
    [Header("Player Settings")]
    [SerializeField] private PlayerController playerPrefab;
    [SerializeField] private Transform playerSpawnPosition;

    [Header("Enemy Spawner Settings")]
    [SerializeField] private EnemySpawner enemySpawnerPrefab;
    [SerializeField] private Transform enemySpawnerPosition;

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
        InitializeEnemySpawner();
    }

    private void InitializeEnemySpawner()
    {
        var enemySpawner = Instantiate(enemySpawnerPrefab, enemySpawnerPosition.position, Quaternion.identity);
    }

    private void InitializePlayer()
    {
        var player = Instantiate(playerPrefab, playerSpawnPosition.position, Quaternion.identity);
    }
}
