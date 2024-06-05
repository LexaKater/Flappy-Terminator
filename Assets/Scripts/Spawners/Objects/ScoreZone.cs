using System;
using System.Collections;
using UnityEngine;

public class ScoreZone : MonoBehaviour, IInteractable, ILifeCycler
{
    [SerializeField] private float _delay = 5f;

    private Coroutine _coroutine;

    public event Action<ScoreZone> LifeEnded;

    private void Start() => _coroutine = StartCoroutine(StartLifeCycle());

    public void Init()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(StartLifeCycle());
    }

    public IEnumerator StartLifeCycle()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        yield return wait;

        LifeEnded?.Invoke(this);
    }
}
