using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Aim : MonoBehaviour, IAim
{
    
    [Header("References")]
    [SerializeField] private Transform aimTransform;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [Header("Options")]
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private float spread = .1f;

    private IEnumerator coroutine;
    
    private void Update()
    {
        TakeSight();
        Shoot();
    }

    private void TakeSight()
    {      
        Vector3 mosuePosition = MousePos.GetMouseWorldPosition();
        Vector3 aimDirection = (mosuePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);      
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 spreadAmount = new Vector2(Random.Range(-spread, spread), 0);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(((Vector2)firePoint.right + (Vector2)spreadAmount) * bulletForce, ForceMode2D.Impulse);
        }
    }

    public void increaseBulletForce()
    {
        bulletForce *= 2f;
        coroutine = doubleBullet(3f);
        StartCoroutine(coroutine);
    }

    private IEnumerator doubleBullet(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        bulletForce /= 2f;
    }
}

