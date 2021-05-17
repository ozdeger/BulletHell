using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDashModule 
{
    bool IsDashing { get; }

    void DoDash(Vector2 dir);
}
