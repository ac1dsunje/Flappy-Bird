using System;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager: IDisposable
{
    private readonly string _scene;
    private readonly BirdController _bird;
    private readonly TextMeshProUGUI _scoreText;

    private int _score;

    public GameManager(string scene, BirdController bird, TextMeshProUGUI scoreText)
    {
        _scene = scene;
        _bird = bird;
        _scoreText = scoreText;

        _bird.OnHit += RestartGame;
        _bird.OnPipePassed += OnPipePassed;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(_scene);
    }

    private void OnPipePassed()
    {
        _score++;
        _scoreText.text = $"Score: {_score}";
    }

    public void Dispose()
    {
        _bird.OnHit -= RestartGame;
        _bird.OnPipePassed -= OnPipePassed;
    }
}