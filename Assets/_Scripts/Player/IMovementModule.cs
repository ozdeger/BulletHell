using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementModule
{
    void UpdateMoveSpeed(float moveSpeed);
    void Move(Vector2 dir);
    void Sprint();
}
