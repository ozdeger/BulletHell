using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputModule : MonoBehaviour, IInputModule
{
    private IMovementModule _movementModule;

    private void Start()
    {
        _movementModule = GetComponent<MovementModule>();
    }

    private void Update()
    {
        Vector2 dir;

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        if(dir != Vector2.zero)
        {
            _movementModule.Move(dir.normalized);
        }
    }
}
