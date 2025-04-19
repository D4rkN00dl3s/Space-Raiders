using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour, IEntityDamageable
{
    [Range(1, 20)]
    [SerializeField] private uint verticalSpeed = 0;
    [SerializeField] private Projectile projectilePrefab;
    private bool readyToShoot = true;
    [SerializeField] private float shootIntervals;

    // Start is called before the first frame update
    void Start()
    {

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
        transform.position += new Vector3(0, input * verticalSpeed * Time.deltaTime, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.parent.TryGetComponent<IEnemyCollidable>(out var entity))
        {
            TakeDamage(2);
        }
    }

    void DestroySelf()
    {
        Debug.Log("We DEAD");
    }

    void ShootHandler()
    {
        if(Input.GetKey(KeyCode.Space) && readyToShoot)
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

    public void TakeDamage(int damage)
    {
        DestroySelf();
    }
}
