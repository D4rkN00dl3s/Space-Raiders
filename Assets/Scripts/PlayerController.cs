using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : EntityBase, IEntityDamageable
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementHandler();
    }

    void MovementHandler()
    {
        float input = Input.GetAxis("Vertical");
        rb.MovePosition(new Vector2(transform.position.x, transform.position.y + input * moveSpeed * Time.deltaTime));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.TryGetComponent<IEnemyCollidable>(out var entity))
        {
            TakeDamage(entity.ReturnDamageFromCollision());
        }
    }
}
