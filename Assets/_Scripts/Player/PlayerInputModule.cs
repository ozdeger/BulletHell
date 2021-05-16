using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputModule : MonoBehaviour, IInputModule
{
    private MovementModifier _modifier;
    private IMovementModule _movementModule;
    private IDashModule _dashModule;




    private void Start()
    {
        _modifier = GetComponent<MovementModifier>();
        _movementModule = GetComponent<IMovementModule>();
        _dashModule = GetComponent<IDashModule>();
    }

    private void Update()
    {
        Vector2 dir;

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        dir = dir.normalized;
        
        if (Input.GetKeyDown("space") && _dashModule.isDashing)
        {
            //_movementModule.Sprint();
            _dashModule.Dash(dir);
        }

        if(dir != Vector2.zero)
        {
            Vector3 modifiedMovement = _modifier.ApplyMovementEffects(dir);
            _movementModule.Move(modifiedMovement);
        }
    }
}
