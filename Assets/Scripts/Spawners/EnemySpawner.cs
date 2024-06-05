using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private Transform[] _spawnPoints;

    protected override void OnGet(Enemy enemy)
    {
        enemy.LifeEnded += OnRelease;
        enemy.transform.position = SetSpawnPoint();
        enemy.gameObject.SetActive(true);
        enemy.Init();
    }

    protected override void OnRelease(Enemy enemy)
    {
        enemy.LifeEnded -= OnRelease;
        base.OnRelease(enemy);
    }

    private Vector3 SetSpawnPoint() => _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
}
