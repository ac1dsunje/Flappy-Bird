using System;
using _Game.Scripts.Movement.Jump;

namespace _Game.Scripts.Player
{
public class PlayerController: IDisposable
{
    private readonly PlayerModel _model;
    private readonly IPlayerView _view;
    private readonly IJumpInput _jumpInput;

    public event Action OnHit;
    public event Action OnPipePassed;

    public PlayerController(PlayerModel model, IPlayerView view, IJumpInput input)
    {
        _model = model;
        _view = view;
        _view.OnHit += OnHitHandle;
        _view.OnPipePassed += OnPipePassedHandle;


        _jumpInput = input;
        _jumpInput.OnJumpPressed += Jump;
    }

    private void Jump()
    {
        _view.Jump(_model.JumpForce);
    }

    private void OnHitHandle() => OnHit?.Invoke();

    private void OnPipePassedHandle() => OnPipePassed?.Invoke();

    public void Dispose()
    {
        _jumpInput.OnJumpPressed -= Jump;
        _view.OnHit -= OnHitHandle;
        _view.OnPipePassed -= OnPipePassedHandle;
    }
}
}