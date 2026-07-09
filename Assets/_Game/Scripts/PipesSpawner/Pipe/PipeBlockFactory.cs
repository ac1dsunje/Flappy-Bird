using _Game.Scripts.Factory;
using UnityEngine;

public class PipeBlockFactory : PooledGameObjectFactory
{
    public PipeBlockFactory(PoolConfig poolConfig) : base(poolConfig) { }

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