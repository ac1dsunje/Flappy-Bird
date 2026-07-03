using UnityEngine;


[CreateAssetMenu(fileName = "Pipe", menuName = "Game/Pipes/Config")]
public class PipeConfigSO : ScriptableObject
{
    [field: SerializeField] public GameObject PipeBlockPrefab { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; } = 3f;

    [field: SerializeField] public int GapCount { get; private set; } = 2;
}