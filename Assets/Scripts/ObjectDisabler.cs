using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.TryGetComponent<IDisableable>(out var entity))
        {
            entity.DisableObject();
        }
    }
}
