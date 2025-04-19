using UnityEngine;

public abstract class EntityBase : MonoBehaviour
{
    protected string entityName;
    protected uint maxHealth;
    protected int currentHealth;
    protected uint moveSpeed;

    public virtual void Initialize(EntityDataSO data)
    {
        entityName = data.Name;
        maxHealth = data.MaxHealth;
        moveSpeed = data.MoveSpeed;
        currentHealth = (int)maxHealth;
    }
}