using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdView : MonoBehaviour, IBirdView
{
    private Rigidbody2D _rb;
    private BirdAnimationSO _config;

    public event Action OnHit;
    public event Action OnPipePassed;

    public BirdView Initialize(BirdAnimationSO config)
    {
        _config = config;
        _rb = GetComponent<Rigidbody2D>();
        return this;
    }

    private void Update()
    {
        RotateDown();
    }

    public void Jump(float jumpSpeed)
    {
        _rb.linearVelocity = Vector2.up * jumpSpeed;
        RotateUp();
    }

    private void RotateDown()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, _config.RotateDownAngle), _config.RotateDownTime * Time.deltaTime);
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
