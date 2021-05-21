using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [Header("Required")]
    [SerializeField] private Transform gunObject;
    [SerializeField] private Transform bullerSpawnPoint;
    [SerializeField] private GameObject bulletBlueprint;


    [Header("Burst Options")]
    
    [SerializeField] private float bulletDelay;
    [SerializeField] private float burstCounter;
    [SerializeField] public enum GunMods { Single, Burst };
    [SerializeField] public GunMods curMode = GunMods.Single;    

    [Header("Single Options")]
    [SerializeField] private float fireRate;

    
    private int gun_mode = 1;
    private Camera _camera;


    private float _lastShot = 0f;
   


    private void Start()
    {
        _camera = CameraManager.Instance.Camera;
    }

    private void Update()
    {
    
    }

    public void ShootBullet()
    {
        if(Time.time > fireRate + _lastShot)
        {
            Shoot();
            _lastShot = Time.time;
        }
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bulletBlueprint);
        newBullet.transform.position = bullerSpawnPoint.position;
        newBullet.AddComponent<BulletController>();
        newBullet.transform.right = gunObject.right;
        newBullet.SetActive(true);
    }

    public void test()
    {
        switch (curMode)
        {
            case GunMods.Single:
                    ShootBullet();
                break;
            case GunMods.Burst:           
                   ShootBurst();
                break;
            default:
                break;
        }
    }


    public void ChangeMode()
    {
        gun_mode *= -1;
        if (gun_mode == 1) { curMode = GunMods.Single; }
        else { curMode = curMode = GunMods.Burst; }
    }

    public void TakeSight(Vector3 vec)
    {
        gunObject.eulerAngles = vec;
    }

    private IEnumerator ShootBurstRoutine()
    {
        for (int i = 0; i < burstCounter; i++)
        {
            Shoot();
            yield return new WaitForSeconds(bulletDelay);
        }
    }
    public void ShootBurst()
    {
        StartCoroutine(ShootBurstRoutine());
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
