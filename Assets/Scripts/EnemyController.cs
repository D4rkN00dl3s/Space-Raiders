using System.Data;
using UnityEngine;

public class EnemyController : EntityBase, IEnemyCollidable, IEntityDamageable, IDisableable
{
    private uint damage;

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

    internal override void Initialize(EntityDamagerDataSO data)
    {
        base.Initialize(data);
        damage = data.damage;
    }

    public uint ReturnDamageFromCollision()
    {
        return damage;
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}