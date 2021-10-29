using UnityEngine;

public class BlocksMover : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    private const float SpeedBlocks = 30f;
    private const float GravityScale = 1.55f;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, -2 * SpeedBlocks);
        _rigidBody.gravityScale = GravityScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Delete delete))
        {
            Destroy(gameObject);
        }
    }
}