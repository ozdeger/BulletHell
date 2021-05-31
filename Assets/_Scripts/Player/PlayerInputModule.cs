using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputModule : MonoBehaviour, IInputModule
{
    [Header("Screen Shake")]
    [SerializeField] private float _length = .03f;
    [SerializeField] private float _power = .03f;

    private MovementModifier _modifier;
    private IMovementModule _movementModule;
    private IDashModule _dashModule;
    private GunController _gunController;

    private Camera _camera;
    private int gunModeFlag = 1;
    

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
        if (gunModeFlag == 1)
        {
            if (Input.GetMouseButton(0))
            {
                _gunController.SwitchShootingMode();
                ScreenShake.instance.StartShake(_length, _power);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _gunController.SwitchShootingMode();
            }
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
            _gunController.ChangeMode();
            gunModeFlag *= -1;
        }
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
