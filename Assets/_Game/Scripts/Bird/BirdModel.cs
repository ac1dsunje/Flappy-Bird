public class BirdModel
{
    public float JumpForce { get; private set; }

    public BirdModel(float jumpSpeed)
    {
        JumpForce = jumpSpeed;
    }
}