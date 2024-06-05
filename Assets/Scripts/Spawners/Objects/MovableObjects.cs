using System.Collections;
using UnityEngine;

public abstract class MovableObjects : MonoBehaviour, ILifeCycler
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay = 5f;

    private Coroutine _coroutine;

    public float Speed => _speed;
    public float Delay => _delay;

    private void Start() => _coroutine = StartCoroutine(StartLifeCycle());

    public abstract IEnumerator StartLifeCycle();

    public virtual void Init()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(StartLifeCycle());
    }

    public virtual void Move() => transform.position = Vector3.MoveTowards(transform.position, SetDirection(), _speed * Time.deltaTime);

    protected virtual Vector3 SetDirection()
    {
        Vector3 direction = transform.position;
        float targetXPosition = -10f;

        direction.x = targetXPosition;

        return direction;
    }
}