using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), (typeof(BulletCollisionHandler)))]
public class BirdBullet : Bullet
{
    private Rigidbody2D _bulletRB;
    private BulletCollisionHandler _collisionBullet;
    private Vector2 _targetPoint;

    public event Action<BirdBullet> LifeEnded;

    private void Awake()
    {
        _collisionBullet = GetComponent<BulletCollisionHandler>();
        _bulletRB = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => _collisionBullet.CollisionDetected += OnDetected;

    private void OnDisable() => _collisionBullet.CollisionDetected -= OnDetected;

    public override void Init() => base.Init();

    public override IEnumerator StartLifeCycle()
    {
        WaitForSeconds wait = new WaitForSeconds(Delay);

        yield return wait;

        LifeEnded?.Invoke(this);
    }

    public override void Move() => _bulletRB.AddForce(_targetPoint * Speed);

    public void SetTargetPoint(Vector2 targetPoint) => _targetPoint = targetPoint;

    private void OnDetected(Enemy enemy)
    {
        LifeEnded?.Invoke(this);
        enemy.PutPool();
    }
}
