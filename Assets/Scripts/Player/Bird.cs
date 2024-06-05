using System;
using UnityEngine;

[RequireComponent(typeof(BirdCollisionHandler), typeof(BirdMover), typeof(ScoreCounter))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private BirdCollisionHandler _handler;
    private ScoreCounter _counter;

    public event Action GameOver;

    private void Awake()
    {
        _handler = GetComponent<BirdCollisionHandler>();
        _birdMover = GetComponent<BirdMover>();
        _counter = GetComponent<ScoreCounter>();
    }

    private void OnEnable() => _handler.CollisionDetected += ProcessCollision;

    private void OnDisable() => _handler.CollisionDetected -= ProcessCollision;

    public void Reset()
    {
        _birdMover.Reset();
        gameObject.SetActive(true);
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is BirdBullet)
            return;

        if (interactable is Earth || interactable is Enemy || interactable is Bullet)
            GameOver?.Invoke();

        if (interactable is ScoreZone)
            _counter.AddScore();
    }
}
