using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipesSpawner : MonoBehaviour
{
    private PipesConfigSO _config;
    private Coroutine _spawnCoroutine;

    private float _spawnInterval;

    public PipesSpawner Initialize(PipesConfigSO config)
    {
        _config = config;
        _spawnInterval = _config.SpawnIntervalMax;
        Run();
        return this;
    }

    private void Run()
    {
        _spawnCoroutine = StartCoroutine(SpawnPipesLoop());
    }

    private IEnumerator SpawnPipesLoop()
    {
        int count = 0;
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
        int rand = Random.Range(0, _config.PipePrefabs.Length);
        var pipe = Instantiate(_config.PipePrefabs[rand], transform, false)
                         .GetComponent<PipeController>();

        pipe.Initialize(_config.MoveSpeed);
    }

    public void OnDisable()
    {
        StopCoroutine(_spawnCoroutine);
    }
}