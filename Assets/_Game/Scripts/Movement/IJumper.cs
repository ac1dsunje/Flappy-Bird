using System;

public enum JumpInputTypes
{
    keyboard,
    mouse
}

public interface IJumper
{
    public event Action OnJumpPressed;
}