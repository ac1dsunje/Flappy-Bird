using UnityEngine;

public class StartBorderChecker: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            Destroy(collision.gameObject);
        }
    }
}