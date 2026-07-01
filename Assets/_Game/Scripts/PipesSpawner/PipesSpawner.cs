using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipesSpawner : MonoBehaviour
{
    private PipesConfigSO _config;
    private Coroutine _spawnCoroutine;

    public PipesSpawner Initialize(PipesConfigSO config)
    {
        _config = config;
        Run();
        return this;
    }

    private void Run()
    {
        _spawnCoroutine = StartCoroutine(SpawnPipesLoop());
    }

    private IEnumerator SpawnPipesLoop()
    {
        while (true)
        {
            SpawnPipe();
            yield return new WaitForSeconds(_config.SpawnInterval);
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