using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputModule : MonoBehaviour, IInputModule
{
    [SerializeField] public enum GunMods { Single, Burst };
    [SerializeField] public GunMods curMode = GunMods.Single;

    private MovementModifier _modifier;
    private IMovementModule _movementModule;
    private IDashModule _dashModule;
    private GunController _gunController;

    private int gun_mode = 1;
    private Camera _camera;

    Vector2 dir;

    private void Start()
    {
        _modifier = GetComponent<MovementModifier>();
        _movementModule = GetComponent<IMovementModule>();
        _dashModule = GetComponent<IDashModule>();
        _gunController = GetComponent<GunController>();

        _camera = CameraManager.Instance.Camera;
    }

    private void Update()
    {

        getMoveDir();
        CheckShoot();
        TakeSightInput();

        if (Input.GetKeyDown("space"))
        {
            //_movementModule.Sprint();
            _dashModule.DoDash(dir);
        }

        if(dir != Vector2.zero && !_dashModule.IsDashing)
        {
            Vector3 modifiedMovement = _modifier.ApplyMovementEffects(dir);
            _movementModule.Move(modifiedMovement);
        }
    }

    public void CheckShoot()
    {
        ChangeGunMode();

        switch (curMode)
        {
            case GunMods.Single:
                if (Input.GetMouseButton(0))
                {
                    _gunController.ShootBullet();
                }
                break;
            case GunMods.Burst:
                if (Input.GetMouseButtonDown(0))
                {
                    _gunController.ShootBurst();
                }
                break;
            default:
                break;
        }
    }

    private void getMoveDir()
    {
        dir = Vector2.zero;

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        dir = dir.normalized;
    }

    private void ChangeGunMode()
    {
        if (Input.GetKeyDown("b"))
        {
            ChangeMode();
        }
    }

    private void ChangeMode()
    {
        gun_mode *= -1;
        if (gun_mode == 1) { curMode = GunMods.Single; }
        else { curMode = curMode = GunMods.Burst; }
    }

    private void TakeSightInput()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        _gunController.TakeSight(new Vector3(0, 0, angle));
    }
}
