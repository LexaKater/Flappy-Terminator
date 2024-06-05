using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreView;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable() => _scoreCounter.ScoreChanged += ShowScore;

    private void OnDisable() => _scoreCounter.ScoreChanged -= ShowScore;

    private void ShowScore(int score) => _scoreView.text = score.ToString();
}
