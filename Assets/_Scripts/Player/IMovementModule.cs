using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementModule
{
    public abstract void Move(Vector2 dir);
    public abstract void Sprint();
    
}
