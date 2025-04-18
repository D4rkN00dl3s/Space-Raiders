using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyCollidable
{
    [Range(1, 20)]
    [SerializeField] private uint moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementHandler();
    }

    void MovementHandler()
    {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0,  0);
    }
}