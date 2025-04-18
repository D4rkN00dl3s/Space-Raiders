using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [Range(1, 20)]
    [SerializeField] private uint verticalSpeed = 0;

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
        float input = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, input * verticalSpeed * Time.deltaTime, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.parent.TryGetComponent<IEnemyCollidable>(out var entity))
        {
            DestroySelf();
        }
    }

    void DestroySelf()
    {
        Debug.Log("We DEAD");
    }
}
