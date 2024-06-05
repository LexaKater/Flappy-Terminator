using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputProcessing))]
public class BirdBulletSpawner : MonoBehaviour
{
    [SerializeField] private BirdBullet _bullet;

    private Queue<BirdBullet> _bulletPool;

    private void Awake() => _bulletPool = new Queue<BirdBullet>();

    public BirdBullet GetBullet()
    {
        if (_bulletPool.Count == 0)
        {
            BirdBullet bullet = Instantiate(_bullet);

            return bullet;
        }

        return _bulletPool.Dequeue();
    }

    public void OnPutBullet(BirdBullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletPool.Enqueue(bullet);

        bullet.LifeEnded -= OnPutBullet;
    }
}
