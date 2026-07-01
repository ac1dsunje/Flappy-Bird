using UnityEngine;

[CreateAssetMenu(fileName = "PipesSpawner", menuName = "Game/PipesSpawner")]
public class PipesConfigSO: ScriptableObject
{
    [field: SerializeField] public GameObject[] PipePrefabs {get; private set;}
    [field: SerializeField] public float SpawnInterval { get; private set; } = 2f;
    [field: SerializeField] public float MoveSpeed { get; private set; } = 3f;
}