using System;

public class BirdController: IDisposable
{
    private readonly BirdModel _model;
    private readonly BirdView _view;
    private readonly IJumpInput _jumpInput;

    public event Action OnHit;
    public event Action OnPipePassed;

    public BirdController(BirdModel model, BirdView view, IJumpInput input)
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
        _view.Jump(_model.JumpForce, _model.RotatePower);
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