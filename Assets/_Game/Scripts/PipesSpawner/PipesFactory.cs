using UnityEngine;

public class PipesFactory : PooledComponentFactory<PipeController>
{
    private readonly PipeBlockFactory _blockFactory;
    public PipesFactory(PoolConfig poolConfig, PipeBlockFactory blockFactory) : base(poolConfig) 
    {
        _blockFactory = blockFactory;
    }

    protected override PipeController Create(GameObject prefab)
    {
        return Object.Instantiate(prefab).GetComponent<PipeController>();
    }

    public PipeController Get(
        GameObject pipePrefab,
        PipeConfigSO pipeConfig,
        Transform parent)
    {
        var pipe = GetItem(pipePrefab);
        pipe.transform.SetParent(parent, false);
        pipe.transform.position = parent.position;
        pipe.Initialize(pipeConfig, _blockFactory);
        return pipe;
    }
}