using UnityEngine;

namespace _Game.Scripts.Borders
{
[CreateAssetMenu(fileName = "BordersConfig", menuName = "Game/BordersConfig")]
public class BordersConfigSO : ScriptableObject
{
    [field: SerializeField] public GameObject Start { get; private set; }
    [field: SerializeField] public GameObject Ground { get; private set; }
    [field: SerializeField] public GameObject Sky { get; private set; }
}
}