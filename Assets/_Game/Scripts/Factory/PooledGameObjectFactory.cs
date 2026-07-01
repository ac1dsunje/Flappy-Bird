using UnityEngine;

public abstract class PooledGameObjectFactory : PooledFactory<GameObject>
{
    protected PooledGameObjectFactory(PoolConfig poolConfig) : base(poolConfig) { }

    protected override void OnGet(GameObject item) => item.SetActive(true);
    protected override void OnRelease(GameObject item) => item.SetActive(false);
    protected override void OnDestroyItem(GameObject item) => Object.Destroy(item);
}