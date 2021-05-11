using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementEffect
{
    public abstract Vector2 Modify(Vector2 movementVector);
}
