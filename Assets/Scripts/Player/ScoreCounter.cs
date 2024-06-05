using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _scoreCount = 0;

    public event Action<int> ScoreChanged;

    public void AddScore()
    {
        _scoreCount++;
        ScoreChanged?.Invoke(_scoreCount);
    }

    public void Reset()
    {
        _scoreCount = 0;
        ScoreChanged?.Invoke(_scoreCount);
    }
}
