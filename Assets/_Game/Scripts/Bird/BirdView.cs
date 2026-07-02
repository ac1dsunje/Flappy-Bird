using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdView : MonoBehaviour
{
    private Rigidbody2D _rb;

    public event Action OnHit;
    public event Action OnPipePassed;

    public BirdView Initialize()
    {
        _rb = GetComponent<Rigidbody2D>();
        return this;
    }

    public void Jump(float jumpSpeed, float rotatePower)
    {
        _rb.linearVelocity = Vector2.up * jumpSpeed;
        RotateUp(rotatePower);
    }

    private void RotateUp(float power)
    {
        transform.eulerAngles = new Vector3(0, 0, _rb.linearVelocityY * power);
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
