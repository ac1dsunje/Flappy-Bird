using System;

public class BirdController: IDisposable
{
    private readonly BirdModel _model;
    private readonly IBirdView _view;
    private readonly IJumpInput _jumpInput;

    public event Action OnHit;
    public event Action OnPipePassed;

    public BirdController(BirdModel model, IBirdView view, IJumpInput input)
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