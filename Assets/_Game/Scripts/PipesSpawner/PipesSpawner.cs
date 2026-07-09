using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.PipesSpawner.Pipe;
using UnityEngine;

namespace _Game.Scripts.PipesSpawner
{
public class PipesSpawner : MonoBehaviour
{
    private PipeSpawnerConfig _config;
    private float _spawnInterval;

    private int _camHeight;
    private readonly List<PipeController> _pipes = new();

    private Coroutine _spawnCoroutine;
    private PipesFactory _pipesFactory;

    public void Initialize(PipeSpawnerConfig config, PipesFactory pipesFactory, int camHeight, Vector3 spawnPoint)
    {
        _config = config;
        _spawnInterval = _config.SpawnIntervalMax;
        _pipesFactory = pipesFactory;
        _camHeight = camHeight;
        
        transform.position = spawnPoint;
        Run();
    }

    private void Run()
    {
        _spawnCoroutine = StartCoroutine(SpawnPipesLoop());
    }

    private IEnumerator SpawnPipesLoop()
    {
        var count = 0;
        while (true)
        {
            SpawnPipe();
            count++; 
            if (count == _config.StepsToSpeedUp && _spawnInterval > _config.SpawnIntervalMin)
            {
                _spawnInterval -= _config.SpeedUpKoef;
                count = 0;
            }
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnPipe()
    {
        var pipe = _pipesFactory.Get(_config.PipePrefab, _config.PipeConfig, transform, _camHeight);

        pipe.OnPipeFinished += OnPipeFinished;
        _pipes.Add(pipe);
    }

    private void OnPipeFinished(PipeController pipe)
    {
        pipe.OnPipeFinished -= OnPipeFinished;
        pipe.ReleaseBlocks();
        _pipes.Remove(pipe);
        _pipesFactory.Release(pipe);
    }

    public void OnDisable()
    {
        StopCoroutine(_spawnCoroutine);
        foreach (var pipe in _pipes)
        {
            pipe.OnPipeFinished -= OnPipeFinished;
        }
    }
}
}