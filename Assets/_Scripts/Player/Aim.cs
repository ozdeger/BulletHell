using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour, IAim
{
    
    [Header("References")]
    [SerializeField] private Transform aimTransform;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [Header("Options")]
    [SerializeField] private float bulletForce = 20f;


    private IEnumerator coroutine;



    private void Update()
    {
        TakeSight();
        Shoot();
    }

    private void TakeSight()
    {
        Vector3 mosuePosition = GetMouseWorldPosition();
        Vector3 aimDirection = (mosuePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
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



    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}

