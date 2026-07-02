using UnityEngine;

[CreateAssetMenu(fileName = "BirdConfig", menuName = "Game/Bird config")]
public class BirdConfigSO : ScriptableObject
{
    [field: SerializeField] public float JumpSpeed { get; private set; }

    [field: SerializeField] public float RotatePower { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public Vector2 SpawnPoint { get; private set; }
}