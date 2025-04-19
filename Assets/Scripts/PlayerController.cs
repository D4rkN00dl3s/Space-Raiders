using System.Collections;
using UnityEngine;

public class PlayerController : EntityBase, IEntityDamageable
{
    [SerializeField] private Projectile projectilePrefab;
    private bool readyToShoot = true;
    [SerializeField] private float shootIntervals;

    // Update is called once per frame
    void Update()
    {
        MovementHandler();
        ShootHandler();
    }

    void MovementHandler()
    {
        float input = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, input * moveSpeed * Time.deltaTime, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.TryGetComponent<IEnemyCollidable>(out var entity))
        {
            TakeDamage(2);
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
