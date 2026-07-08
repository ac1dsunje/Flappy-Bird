using System;

namespace _Game.Scripts.Movement.Jump
{
public interface IJumpInput
{
    public event Action OnJumpPressed;
}
}