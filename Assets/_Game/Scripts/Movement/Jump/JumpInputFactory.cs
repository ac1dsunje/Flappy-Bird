using System;
using UnityEngine;
using Object = UnityEngine.Object;

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
        switch (_config.Type)
        {
            case JumpInputTypes.keyboard:
                return Object.Instantiate(_config.KeyboardPrefab)
                    .GetComponent<IJumpInput>();

            case JumpInputTypes.mouse:
                return Object.Instantiate(_config.MousePrefab)
                    .GetComponent<IJumpInput>();

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}