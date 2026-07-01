using UnityEngine;

public enum JumpInputTypes
{
    keyboard,
    mouse
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
        IJumpInput _jumper = null;
        switch (_config.Type)
        {
            case (JumpInputTypes.keyboard):
                _jumper = Object.Instantiate(_config.KeyboardPrefab).GetComponent<IJumpInput>();
                break;

            case (JumpInputTypes.mouse):
                _jumper = Object.Instantiate(_config.MousePrefab).GetComponent<IJumpInput>();
                break;
        }
        return _jumper;
    }
}