using UnityEngine;


[CreateAssetMenu(fileName = "JumpInputsConfig", menuName = "Game/Jump inputs config")]
public class JumpInputSO : ScriptableObject
{
    [field : SerializeField] public JumpInputTypes Type { get; private set; }

    [field: SerializeField] public GameObject KeyboardPrefab { get; private set; }
    [field: SerializeField] public GameObject MousePrefab { get; private set; }
}