using UnityEngine;

namespace _Game.Scripts.PipesSpawner
{
[CreateAssetMenu(fileName = "PipeSpawner", menuName = "Game/Pipes/Spawner")]
public class PipeSpawnerConfig: ScriptableObject
{
    [field: SerializeField] public GameObject PipeSpawnerPrefab { get; private set; }
    [field: SerializeField] public PipeConfigSO PipeConfig { get; private set; }
    [field: SerializeField] public GameObject PipePrefab { get; private set; }
    [field: SerializeField] public float SpawnIntervalMax { get; private set; } = 2f;
    [field: SerializeField] public float SpawnIntervalMin { get; private set; } = 1f;
    [field: SerializeField] public int StepsToSpeedUp { get; private set; } = 10;
    [field: SerializeField] public float SpeedUpKoef { get; private set; } = 0.1f;
}
}