using UnityEngine;

public class EnemyController : EntityBase, IEnemyCollidable, IEntityDamageable
{

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