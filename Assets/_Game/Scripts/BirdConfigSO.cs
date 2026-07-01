using UnityEngine;

[CreateAssetMenu(fileName = "BirdConfig", menuName = "Game/Bird config")]
public class BirdConfigSO : ScriptableObject
{
    [field: SerializeField] public MovementConfigSO Movement { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public Vector2 SpawnPoint { get; private set; }
}