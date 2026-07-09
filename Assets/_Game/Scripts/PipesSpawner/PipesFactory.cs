using _Game.Scripts.Factory;
using _Game.Scripts.PipesSpawner.Pipe;
using UnityEngine;

namespace _Game.Scripts.PipesSpawner
{
public class PipesFactory : PooledComponentFactory<PipeController>
{
    private readonly PipeBlockFactory _blockFactory;
    public PipesFactory(PoolConfig poolConfig, PipeBlockFactory blockFactory) : base(poolConfig) 
    {
        _blockFactory = blockFactory;
    }

    public PipeController Get(
        GameObject pipePrefab,
        PipeConfigSO pipeConfig,
        Transform parent,
        int camHeight)
    {
        var pipe = GetItem(pipePrefab);
        pipe.transform.SetParent(parent, false);
        pipe.transform.position = parent.position;
        pipe.Initialize(pipeConfig, _blockFactory, camHeight);
        return pipe;
    }
}
}