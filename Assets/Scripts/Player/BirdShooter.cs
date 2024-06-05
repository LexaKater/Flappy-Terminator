using UnityEngine;

[RequireComponent(typeof(InputProcessing), (typeof(BirdBulletSpawner)))]
public class BirdShooter : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private BirdBullet _birdBullet;
    private InputProcessing _input;
    private BirdBulletSpawner _bulletSpawner;

    private void Update() => Shoot();

    private void Awake()
    {
        _bulletSpawner = GetComponent<BirdBulletSpawner>();
        _input = GetComponent<InputProcessing>();
    }

    private void Shoot()
    {
        if (_input.TryShoot())        
            Spawn();
    }

    private void Spawn()
    {
        Vector2 targetPoint = Quaternion.AngleAxis(transform.rotation.eulerAngles.z, Vector3.forward) * Vector2.right;

        _birdBullet = _bulletSpawner.GetBullet();

        _birdBullet.gameObject.SetActive(true);
        _birdBullet.LifeEnded += _bulletSpawner.OnPutBullet;

        _birdBullet.Init();
        _birdBullet.SetTargetPoint(targetPoint);
        _birdBullet.Move();

        _birdBullet.transform.position = _spawnPoint.position;
    }
}
