using UnityEngine;

[CreateAssetMenu(fileName = "PipesSpawner", menuName = "Game/PipesSpawner")]
public class PipesConfigSO: ScriptableObject
{
    [field: SerializeField] public GameObject[] PipePrefabs {get; private set;}
    [field: SerializeField] public float SpawnIntervalMax { get; private set; } = 2f;
    [field: SerializeField] public float SpawnIntervalMin { get; private set; } = 1f;
    [field: SerializeField] public int StepsToSpeedUp { get; private set; } = 10;
    [field: SerializeField] public float SpeedUpKoef { get; private set; } = 0.1f;
    [field: SerializeField] public float MoveSpeed { get; private set; } = 3f;
}