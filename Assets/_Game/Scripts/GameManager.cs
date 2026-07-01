using System;
using UnityEngine.SceneManagement;

public class GameManager: IDisposable
{
    private readonly string _scene;
    private readonly BirdController _bird;

    public GameManager(string scene, BirdController bird)
    {
        _scene = scene;
        _bird = bird;

        _bird.OnWallHit += RestartGame;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(_scene);
    }

    public void Dispose()
    {
        _bird.OnWallHit -= RestartGame;
    }
}