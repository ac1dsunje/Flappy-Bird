using UnityEngine;


[CreateAssetMenu(fileName = "MovementConfig", menuName = "Game/Movement config")]
public class MovementConfigSO : ScriptableObject
{
    [field: SerializeField] public float RotatePower { get; private set; }
    [field: SerializeField] public float JumpSpeed { get; private set; }
}