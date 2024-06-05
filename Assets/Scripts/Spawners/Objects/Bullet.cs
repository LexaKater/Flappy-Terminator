using System;
using System.Collections;
using UnityEngine;

public class Bullet : MovableObjects, ILifeCycler, IInteractable
{
    public event Action<Bullet> LifeEnded;

    private void Update() => Move();

    public override void Init() => base.Init();

    public override IEnumerator StartLifeCycle()
    {
        WaitForSeconds wait = new WaitForSeconds(Delay);

        yield return wait;

        LifeEnded?.Invoke(this);
    }

    public override void Move() => base.Move();

    protected override Vector3 SetDirection() => base.SetDirection();
}
