using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class MovementModifier : MonoBehaviourWithLog
{
    public IMovementEffect[] _movementEffects;

    private void Start()
    {
        DetectMovementEffect();    
    }

    public void DetectMovementEffect()
    {
        _movementEffects = GetComponents<IMovementEffect>();
    }

    public Vector2 ApplyMovementEffects(Vector2 movementVector)
    {
        Vector2 newMovementVector = movementVector;
        foreach(IMovementEffect effect in _movementEffects)
        { 
            newMovementVector = effect.Modify(newMovementVector);
        }
        return newMovementVector;
    }
}
