using System;
using UnityEngine;

public class JumpHandlerSpace : MonoBehaviour, IJumper
{
    public event Action OnJumpPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpPressed?.Invoke();
        }
    }
}