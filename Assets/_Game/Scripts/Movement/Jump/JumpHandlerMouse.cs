using System;
using UnityEngine;

public class JumpHandlerMouse : MonoBehaviour, IJumper
{
    public event Action OnJumpPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnJumpPressed?.Invoke();
        }
    }
}