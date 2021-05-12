using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI_InputModule : MonoBehaviour,IInputModule
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

        dir = PlayerManager.Instance.Player.position - transform.position;
        dir = dir.normalized;

        if (dir != Vector2.zero)
        {
            Vector3 modifiedMovement = _modifier.ApplyMovementEffects(dir);
            _movementModule.Move(modifiedMovement);
        }
    }


}
