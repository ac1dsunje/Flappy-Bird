using UnityEngine;

[CreateAssetMenu(fileName = "BirdConfig", menuName = "Game/Bird/Config")]
public class BirdConfigSO : ScriptableObject
{
    [field: SerializeField] public float JumpSpeed { get; private set; }
    [field: SerializeField] public BirdAnimationSO Animation { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public Vector2 SpawnPoint { get; private set; }
}