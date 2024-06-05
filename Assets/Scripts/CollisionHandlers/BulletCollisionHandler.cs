using System;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    public event Action<Enemy> CollisionDetected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            CollisionDetected?.Invoke(enemy);
    }
}
