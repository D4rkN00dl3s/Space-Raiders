using System;
using UnityEngine;

public class SceneInitializer : MonoBehaviour

{
    [Header("Player Settings")]
    [SerializeField] private PlayerController playerPrefab;
    [SerializeField] private Transform playerSpawnPosition;
    [SerializeField] private EntityDataSO playerConfig;

    [Header("Enemy Spawner Settings")]
    [SerializeField] private EnemySpawner enemySpawnerPrefab;
    [SerializeField] private Transform enemySpawnerPosition;
    [SerializeField] private EntityDataSO enemyConfig;

    private EnemySpawner enemySpawner;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
        InitializeEnemySpawner();
        StartSpawningEnemies();
    }

    private void InitializeEnemySpawner()
    {
        enemySpawner = Instantiate(enemySpawnerPrefab, enemySpawnerPosition.position, Quaternion.identity);
    }

    private void InitializePlayer()
    {
        player = Instantiate(playerPrefab, playerSpawnPosition.position, Quaternion.identity);
        player.Initialize(playerConfig);
    }

    private void StartSpawningEnemies()
    {
        enemySpawner.StartCoroutine(enemySpawner.SpawnWithDelay(enemyConfig));
    }
}
