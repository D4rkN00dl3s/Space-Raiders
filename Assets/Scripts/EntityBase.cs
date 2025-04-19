using UnityEngine;

public abstract class EntityBase : MonoBehaviour, IEntityDamageable
{
    protected string entityName;
    protected uint maxHealth;
    protected int currentHealth;
    protected uint moveSpeed;


    internal virtual void Initialize(EntityDataSO data)
    {
        ApplyBaseData(data);
    }

    internal virtual void Initialize(EntityDamagerDataSO data)
    {
        ApplyBaseData(data);
    }

    protected void ApplyBaseData(EntityDataSO data)
    {
        entityName = data.Name;
        maxHealth = data.MaxHealth;
        moveSpeed = data.MoveSpeed;
        currentHealth = (int)maxHealth;
    }

    protected virtual void CheckIfDead()
    {
        if(currentHealth <= 0) Destroy(this.gameObject);
    }

    public virtual void TakeDamage(uint damage)
    {
        currentHealth -= (int)damage;
        CheckIfDead();
    }

}