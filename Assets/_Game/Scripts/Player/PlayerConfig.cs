using UnityEngine;

namespace _Game.Scripts.Player
{
[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/Player/Config")]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public float JumpSpeed { get; private set; }
    [field: SerializeField] public PlayerViewConfig Animation { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public Vector2 SpawnPoint { get; private set; }
}
}