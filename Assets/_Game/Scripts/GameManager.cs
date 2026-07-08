using System;
using _Game.Scripts.Player;
using TMPro;
using UnityEngine.SceneManagement;

namespace _Game.Scripts
{
public class GameManager: IDisposable
{
    private readonly string _scene;
    private readonly PlayerController _player;
    private readonly TextMeshProUGUI _scoreText;

    private int _score;

    public GameManager(string scene, PlayerController player, TextMeshProUGUI scoreText)
    {
        _scene = scene;
        _player = player;
        _scoreText = scoreText;

        _player.OnHit += RestartGame;
        _player.OnPipePassed += OnPipePassed;
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
        _player.OnHit -= RestartGame;
        _player.OnPipePassed -= OnPipePassed;
    }
}
}