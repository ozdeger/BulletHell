using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputModule : MonoBehaviour, IInputModule
{
    private MovementModifier _modifier;
    private IMovementModule _movementModule;

    private void Start()
    {
        _modifier = GetComponent<MovementModifier>();
        _movementModule = GetComponent<IMovementModule>();
    }

    private void Update()
    {
        Vector2 dir;

        if (Input.GetKeyDown("space"))
        {
            _movementModule.Sprint();
        }

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        if(dir != Vector2.zero)
        {
            Vector3 modifiedMovement = _modifier.ApplyMovementEffects(dir);
            _movementModule.Move(dir.normalized);
        }
    }

   
}
