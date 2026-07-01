using UnityEngine;

public class PipesFactory : PooledComponentFactory<PipeController>
{
    public PipesFactory(PoolConfig poolConfig) : base(poolConfig) { }

    protected override PipeController Create(GameObject prefab)
    {
        return Object.Instantiate(prefab).GetComponent<PipeController>();
    }

    public PipeController Get(
        GameObject prefab,
        Transform parent,
        float moveSpeed)
    {
        var pipe = GetItem(prefab);
        pipe.transform.SetParent(parent, false);
        pipe.transform.localPosition = parent.position;
        pipe.Initialize(moveSpeed);
        return pipe;
    }
}