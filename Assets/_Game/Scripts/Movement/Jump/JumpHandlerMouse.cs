using System;
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