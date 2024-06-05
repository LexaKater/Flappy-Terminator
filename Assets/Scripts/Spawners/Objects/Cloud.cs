using System;
using UnityEngine;
using System.Collections;

public class Cloud : MovableObjects, ILifeCycler
{
    public event Action<Cloud> LifeEnded;

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