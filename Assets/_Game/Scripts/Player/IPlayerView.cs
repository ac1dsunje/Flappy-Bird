using System;

namespace _Game.Scripts.Player
{
public interface IPlayerView
{
    public event Action OnHit;
    public event Action OnPipePassed;

    void Jump(float jumpSpeed);
}
}