using UnityEngine;

namespace _Game.Scripts.Player
{
[CreateAssetMenu(fileName = "playerAnimationConfig", menuName = "Game/Player/animation config")]
public class PlayerViewConfig : ScriptableObject
{
    [field: SerializeField] public float RotatePower { get; private set; }
    [field: SerializeField] public float RotateDownAngle { get; private set; } = -45f;
    [field: SerializeField] public float RotateDownTime { get; private set; } = 7f;
}
}