using UnityEngine;

public abstract class PooledComponentFactory<T> : PooledFactory<T> where T : Component
{
    protected PooledComponentFactory(PoolConfig poolConfig) : base(poolConfig) { }

    protected override void OnGet(T item) => item.gameObject.SetActive(true);
    protected override void OnRelease(T item) => item.gameObject.SetActive(false);
    protected override void OnDestroyItem(T item) => Object.Destroy(item.gameObject);
}