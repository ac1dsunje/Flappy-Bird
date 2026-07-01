using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdController : MonoBehaviour
{
    private MovementConfigSO _config;
    private Rigidbody2D _rb;
    private IJumpInput _input;

    public event Action OnHit;
    public event Action OnPipePassed;

    public BirdController Initialize(MovementConfigSO config, IJumpInput input)
    {
        _config = config; 
        _input = input;

        _input.OnJumpPressed += Jump;

        _rb = GetComponent<Rigidbody2D>();
        return this;
    }

    private void OnDisable()
    {
        _input.OnJumpPressed -= Jump;
    }

    private void Jump()
    {
        _rb.linearVelocity = Vector2.up * _config.JumpSpeed;
        RotateUp();
    }

    private void RotateUp()
    {
        transform.eulerAngles = new Vector3(0, 0, _rb.linearVelocityY * _config.RotatePower);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe") || other.gameObject.CompareTag("Border"))
        {
            OnHit?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            OnPipePassed?.Invoke();
        }
    }
}
