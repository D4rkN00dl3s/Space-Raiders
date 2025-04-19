using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : EntityBase, IEntityDamageable
{
    [SerializeField] private Projectile projectilePrefab;
    private bool readyToShoot = true;
    [SerializeField] private float shootIntervals;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementHandler();
        ShootHandler();
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

    void ShootHandler()
    {
        if (Input.GetKey(KeyCode.Space) && readyToShoot)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.SetParent(transform);
            StartCoroutine(ShootCooldown(shootIntervals));
        }
    }

    IEnumerator ShootCooldown(float seconds)
    {
        readyToShoot = false;
        yield return new WaitForSeconds(seconds);
        readyToShoot = true;
    }
}
