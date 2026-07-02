public class BirdModel
{
    public float JumpForce { get; private set; }
    public float RotatePower { get; private set; }

    public BirdModel(MovementConfigSO config)
    {
        JumpForce = config.JumpSpeed;
        RotatePower = config.RotatePower;
    }
}