 using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdController : MonoBehaviour
{
    private MovementConfigSO _config;
    private Rigidbody2D _rb;
    private string _scene;

    public BirdController Initialize(MovementConfigSO config, string scene)
    {
        _config = config; 
        _scene = scene;

        _rb = GetComponent<Rigidbody2D>();
        return this;
    }

    private void Update()
    {
        if (!CheckJumpButton()) return;
        Jump();
        Rotate();
    }

    private bool CheckJumpButton()
    {
        return (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0));
    }

    private void Jump()
    {
        _rb.linearVelocity = Vector2.up * _config.JumpSpeed;
    }

    private void Rotate()
    {
        transform.eulerAngles = new Vector3(0, 0, _rb.linearVelocityY * _config.RotatePower);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            SceneManager.LoadScene(_scene);
        }
    }
}
