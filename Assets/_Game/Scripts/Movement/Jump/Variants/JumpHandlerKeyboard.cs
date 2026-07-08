using System;
using _Game.Scripts.Movement.Jump;
using UnityEngine;

public class JumpHandlerKeyboard : MonoBehaviour, IJumpInput
{
    public event Action OnJumpPressed;

    [SerializeField] private KeyCode[] _keys;

    private void Update()
    {
        CheckKeys();
    }

    private void CheckKeys()
    {
        for (int i = 0; i < _keys.Length; i++)
        {
            if (Input.GetKeyDown(_keys[i]))
            {
                OnJumpPressed?.Invoke();
                return;
            }
        }
    }
}