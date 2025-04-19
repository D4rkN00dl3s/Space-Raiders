using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float moveSpeed;
    [SerializeField] private int damage;
    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetParent(Transform _parent)
    {
        parent = _parent;
    }

    private void Move()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent == parent)
        {
            return;
        }

        if (other.transform.parent.TryGetComponent<IEntityDamageable>(out var entity))
        {
            entity.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}