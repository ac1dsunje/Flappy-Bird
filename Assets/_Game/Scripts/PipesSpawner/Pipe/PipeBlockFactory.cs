using UnityEngine;

public class PipeBlockFactory : PooledGameObjectFactory
{
    public PipeBlockFactory(PoolConfig poolConfig) : base(poolConfig) { }

    protected override GameObject Create(GameObject prefab)
    {
        return Object.Instantiate(prefab);
    }

    public GameObject Get(
        GameObject prefab,
        Transform parent,
        Vector3 position)
    {
        var block = GetItem(prefab);
        block.transform.localPosition = position;
        block.transform.SetParent(parent, false);
        return block;
    }
}