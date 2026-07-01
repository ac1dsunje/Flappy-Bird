using UnityEngine;

public class PipeController: MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveSpeed;

    public void Initialize(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rb == null) return;

        _rb.linearVelocity = Vector2.left * _moveSpeed;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }

}