using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BulletSpawner))]
public class Enemy : MovableObjects, IInteractable, ILifeCycler
{
    private BulletSpawner _bulletSpawner;

    public event Action<Enemy> LifeEnded;

    private void Awake() => _bulletSpawner = GetComponent<BulletSpawner>();

    private void Update() => Move();

    public override void Init()
    {
        base.Init();
        _bulletSpawner.Init();
    }

    public override IEnumerator StartLifeCycle()
    {
        WaitForSeconds wait = new WaitForSeconds(Delay);

        yield return wait;

        LifeEnded?.Invoke(this);
    }

    public override void Move() => base.Move();

    public void PutPool() => LifeEnded?.Invoke(this);

    protected override Vector3 SetDirection() => base.SetDirection();
}