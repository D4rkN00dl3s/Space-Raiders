using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyCollidable, IEntityDamageable
{
    [Range(1, 20)]
    [SerializeField] private uint moveSpeed;
    [SerializeField] private uint maxHealth;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = (int)maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MovementHandler();
    }

    void MovementHandler()
    {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Enemy: taken {damage} and have {currentHealth} HP left.");
    }
}