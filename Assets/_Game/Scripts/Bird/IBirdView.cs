using System;

public interface IBirdView
{
    public event Action OnHit;
    public event Action OnPipePassed;

    void Jump(float jumpSpeed);
}