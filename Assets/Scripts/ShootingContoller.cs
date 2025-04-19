using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootingContoller : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private uint projectileInPool;
    [SerializeField] private float shootIntervals;
    private bool readyToShoot = true;
    private List<Projectile> projectilePool = new();

    void Update()
    {
        ShootHandler();
    }

    public void Initialize()
    {
        for (uint i = 0; i <= projectileInPool; i++)
        {
            var newProjectile = Instantiate(projectilePrefab, transform);
            newProjectile.SetParent(transform.parent);
            DisableObject(newProjectile);
            projectilePool.Add(newProjectile);
        }
    }
    IEnumerator ShootCooldown(float seconds)
    {
        readyToShoot = false;
        yield return new WaitForSeconds(seconds);
        readyToShoot = true;
    }

    void ShootHandler()
    {
        if (Input.GetKey(KeyCode.Space) && readyToShoot)
        {
            var projectile = projectilePool.FirstOrDefault(go => !go.gameObject.activeSelf);
            projectile.transform.position = transform.position;
            ActivateObject(projectile);
            StartCoroutine(ShootCooldown(shootIntervals));
        }
    }

    public void ActivateObject(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
    }

    public void DisableObject(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }

}
