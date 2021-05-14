using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour, IAim
{
    private enum GunModes { Single, Shotgun}
    private static float spreadIntensityMultiplier = 4;

    [Header("References")]
    [SerializeField] private Transform aimTransform;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [Header("General Options")]
    [SerializeField] private GunModes gunMode;
    [SerializeField] private float bulletForce = 20f;
    [Header("Shotgun Options")]
    [SerializeField] private float spread;
    [SerializeField] private float spreadRandomness;
    [SerializeField] private float bulletCount;


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
            switch (gunMode)
            {
                case GunModes.Single:
                    ShootSingle();
                    break;
                case GunModes.Shotgun:
                    ShootShotgun();
                    break;
                default:
                    break;
            }
        }
    }

    private void ShootSingle()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    private void ShootShotgun()
    {
        float spreadIncreasePerBullet = (spread * 2) / (bulletCount - 1);
        float curSpread = -spread;

        for (int i = 0; i < bulletCount; i++)
        {
            Debug.Log(curSpread);
            //summon bullet prefab
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            // get a random direction for new bullet
            float calculatedSpread = (curSpread + Random.Range(-spreadRandomness, spreadRandomness));
            Vector2 dir = ((Vector2)firePoint.transform.position + ((Vector2)firePoint.right * spreadIntensityMultiplier) + ((Vector2)firePoint.up * calculatedSpread)).normalized;
            Debug.DrawRay(firePoint.position, dir*10, Color.red, 8);
            Debug.DrawRay(firePoint.position, firePoint.right*10, Color.green, 8);
            curSpread += spreadIncreasePerBullet;
            
            //add force to bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(dir * bulletForce, ForceMode2D.Impulse);

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

