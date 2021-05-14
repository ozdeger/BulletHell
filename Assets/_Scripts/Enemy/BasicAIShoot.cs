using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAIShoot : MonoBehaviour
{
    [SerializeField] private float shootDistance;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shootCdTime;

    private bool canShoot = true;

    private void Update()
    {
        if (Vector2.Distance(PlayerManager.Instance.Player.position, transform.position) < shootDistance)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!canShoot) return;

        Vector2 dir;
        dir = PlayerManager.Instance.Player.position - transform.position;
        dir = dir.normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.right = dir;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(dir * bulletForce, ForceMode2D.Impulse);
        canShoot = false;
        Invoke(nameof(ResetShoot), shootCdTime);
    }

    private void ResetShoot()
    {
        canShoot = true;
    }
}
