public class PlayerModel
{
    public float JumpForce { get; private set; }

    public PlayerModel(float jumpSpeed)
    {
        JumpForce = jumpSpeed;
    }
}