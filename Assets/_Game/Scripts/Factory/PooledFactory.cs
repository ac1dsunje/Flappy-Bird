using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace _Game.Scripts.Factory
{
public abstract class PooledFactory<T> where T : class
{
    protected readonly PoolConfig _poolConfig;

    private readonly Dictionary<GameObject, ObjectPool<T>> _poolsByPrefab = new();
    private readonly Dictionary<T, ObjectPool<T>> _instanceToPool = new();

    protected PooledFactory(PoolConfig poolConfig)
    {
        _poolConfig = poolConfig;
    }

    protected abstract T Create(GameObject prefab);

    protected virtual void OnGet(T item) { }
    protected virtual void OnRelease(T item) { }
    protected virtual void OnDestroyItem(T item) { }

    protected T GetItem(GameObject prefab)
    {
        var pool = GetOrCreatePool(prefab);
        var item = pool.Get();
        _instanceToPool[item] = pool;
        OnGet(item);
        return item;
    }

    public void Release(T item)
    {
        if (item == null) return;

        if (_instanceToPool.TryGetValue(item, out var pool))
        {
            OnRelease(item);
            pool.Release(item);
            _instanceToPool.Remove(item);
        }
    }

    private ObjectPool<T> GetOrCreatePool(GameObject prefab)
    {
        if (!_poolsByPrefab.TryGetValue(prefab, out var pool))
        {
            pool = new ObjectPool<T>(
                createFunc: () => Create(prefab),
                actionOnGet: null,
                actionOnRelease: null,
                actionOnDestroy: OnDestroyItem,
                collectionCheck: false,
                defaultCapacity: _poolConfig.DefaultCapacity,
                maxSize: _poolConfig.MaxSize
            );
            _poolsByPrefab[prefab] = pool;
        }
        return pool;
    }
}
}