using UnityEngine;

[CreateAssetMenu(fileName = "BirdAnimationConfig", menuName = "Game/Bird/animation config")]
public class BirdAnimationSO : ScriptableObject
{
    [field: SerializeField] public float RotatePower { get; private set; }
    [field: SerializeField] public float RotateDownAngle { get; private set; } = -45f;
    [field: SerializeField] public float RotateDownTime { get; private set; } = 7f;
}