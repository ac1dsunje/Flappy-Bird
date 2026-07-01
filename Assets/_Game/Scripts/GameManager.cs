using System;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class GameManager: IDisposable
{
    private readonly string _scene;
    private readonly BirdController _bird;

    public GameManager(string scene, BirdController bird)
    {
        _scene = scene;
        _bird = bird;

        _bird.OnHit += RestartGame;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(_scene);
    }

    private void OnPipePassed()
    {
        Debug.Log("Pipe passed");
    }

    public void Dispose()
    {
        _bird.OnHit -= RestartGame;
    }
}