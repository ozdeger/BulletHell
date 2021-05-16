using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDashModule 
{
    bool isDashing { get; }

    public abstract void Dash(Vector2 dir);
}
