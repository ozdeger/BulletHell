using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Required")]
    [SerializeField] private Transform gunObject;
    [SerializeField] private Transform bullerSpawnPoint;
    [SerializeField] private GameObject bulletBlueprint;

    private Camera _camera;

    private void Start()
    {
        _camera = CameraManager.Instance.Camera;
    }

    private void Update()
    {
        TakeSight();
        CheckShoot();
    }

    private void CheckShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        GameObject newBullet = Instantiate(bulletBlueprint);
        newBullet.transform.position = bullerSpawnPoint.position;
        newBullet.AddComponent<BulletController>();
        newBullet.transform.right = gunObject.right;
        newBullet.SetActive(true);
    }

    private void TakeSight()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gunObject.eulerAngles = new Vector3(0, 0, angle);
    }

    //private void ShootShotgun()
    //{
    //    float spreadIncreasePerBullet = (spread * 2) / (bulletCount - 1);
    //    float curSpread = -spread;

    //    for (int i = 0; i < bulletCount; i++)
    //    {
    //        Debug.Log(curSpread);
    //        //summon bullet prefab
    //        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    //        // get a random direction for new bullet
    //        float calculatedSpread = (curSpread + Random.Range(-spreadRandomness, spreadRandomness));
    //        Vector2 dir = ((Vector2)firePoint.transform.position + ((Vector2)firePoint.right * spreadIntensityMultiplier) + ((Vector2)firePoint.up * calculatedSpread)).normalized;
    //        Debug.DrawRay(firePoint.position, dir * 10, Color.red, 8);
    //        Debug.DrawRay(firePoint.position, firePoint.right * 10, Color.green, 8);
    //        curSpread += spreadIncreasePerBullet;

    //        //add force to bullet
    //        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    //        rb.AddForce(dir * bulletForce, ForceMode2D.Impulse);

    //    }
    //}

    
}
