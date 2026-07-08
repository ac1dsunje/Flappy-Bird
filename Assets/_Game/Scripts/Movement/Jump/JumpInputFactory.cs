using System;
using Object = UnityEngine.Object;

namespace _Game.Scripts.Movement.Jump
{
public enum JumpInputTypes
{
    Keyboard,
    Mouse
}

public class JumpInputFactory
{
    private readonly JumpInputSO _config;

    public JumpInputFactory(JumpInputSO config)
    {
        _config = config;
    }

    public IJumpInput Get()
    {
        return _config.Type switch
        {
            JumpInputTypes.Keyboard => Object.Instantiate(_config.KeyboardPrefab).GetComponent<IJumpInput>(),
            JumpInputTypes.Mouse => Object.Instantiate(_config.MousePrefab).GetComponent<IJumpInput>(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
}