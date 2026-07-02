using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdView : MonoBehaviour, IBirdView
{
    private Rigidbody2D _rb;
    private float _rotatePower;

    public event Action OnHit;
    public event Action OnPipePassed;

    public BirdView Initialize(float rotatePower)
    {
        _rotatePower = rotatePower;
        _rb = GetComponent<Rigidbody2D>();
        return this;
    }

    public void Jump(float jumpSpeed)
    {
        _rb.linearVelocity = Vector2.up * jumpSpeed;
        RotateUp();
    }

    private void RotateUp()
    {
        transform.eulerAngles = new Vector3(0, 0, _rb.linearVelocityY * _rotatePower);
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
