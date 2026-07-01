using UnityEngine;

[CreateAssetMenu(fileName = "PoolConfig", menuName = "Game/Pool Config")]
public class PoolConfig: ScriptableObject
{
    [field: SerializeField] public int DefaultCapacity { get; private set; } = 10;
    [field: SerializeField] public int MaxSize { get; private set; } = 10;
}