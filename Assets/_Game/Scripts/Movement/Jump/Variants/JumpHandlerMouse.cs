using System;
using _Game.Scripts.Movement.Jump;
using UnityEngine;

public class JumpHandlerMouse : MonoBehaviour, IJumpInput
{
    public event Action OnJumpPressed;

    private void Update()
    {
        CheckKeys();
    }

    private void CheckKeys()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnJumpPressed?.Invoke();
        }
    }
}