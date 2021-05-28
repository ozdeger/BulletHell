using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class EnemyAIShoot : MonoBehaviour
{
    [Header("Requires")]
    [SerializeField] private GameObject bulletBlueprint;
    [SerializeField] private float range;

    private GunController _gunController;
    private Camera _camera;

    private Vector2 playerColliderCenter;

    void Start()
    {
        _gunController = GetComponent<GunController>();
        _camera = CameraManager.Instance.Camera;
        bulletBlueprint.GetComponent<BulletDealDamage>().UpdateBulletDamage(25);//ask gokay
        
    }
    void Update()
    {
        GetLine();
        TakeSightInput();
        var bulletSpeed = FindObjectOfType<BulletMoveNormal>();//ask gokay
        if (bulletSpeed) { bulletSpeed.UpdateBulletSpeed(10); }
    }

    private void GetLine()
    {
        playerColliderCenter = PlayerManager.Instance.Player.GetComponent<Collider2D>().bounds.center;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, (playerColliderCenter - (Vector2)transform.position ).normalized, range);
          
        if (hit.collider.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Player))
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);
            _gunController.test();
        }

        else
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
        }
    }

    private void TakeSightInput()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(playerColliderCenter);
        mousePosition.z = 0;
        Vector3 aimDirection = (playerColliderCenter - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        _gunController.TakeSight(new Vector3(0, 0, angle));
    }
}
