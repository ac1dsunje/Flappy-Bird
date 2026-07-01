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

    public IJumper Get()
    {
        IJumper _jumper = null;
        if (_config.Type == JumpInputTypes.keyboard)
        {
            _jumper = Object.Instantiate(_config.KeyboardPrefab).GetComponent<IJumper>();
        }
        else if (_config.Type == JumpInputTypes.mouse)
        {
            _jumper = Object.Instantiate(_config.MousePrefab).GetComponent<IJumper>();
        }
        return _jumper;
    }
}