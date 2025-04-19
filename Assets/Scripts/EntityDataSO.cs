using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Data", menuName = "Create Entity Data")]
public class EntityDataSO : ScriptableObject
{
    public string Name;
    public uint MaxHealth;
    public uint MoveSpeed;
}
