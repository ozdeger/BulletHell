using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashModule2 : MonoBehaviour, IDashModule
{
    public float speed = 10f;
    public float dashLength = 0.15f;
    public float dashSpeed = 100f;
    public float dashResetTime = 1f;

    private Vector3 dashMove;
    private float dashing = 0f;
    private float dashingTime = 0f;
    private bool canDash = true;
    private bool dashingNow = false;
    private bool dashReset = true;

    private IMovementModule _movementModule;
    public bool IsDashing { get => canDash; }

    void Start()
    {
        _movementModule = GetComponent<IMovementModule>();
        test();
    }

    public void DoDash(Vector2 dir)
    {
        dashMove = dir;
    }

    private void test()
    {
        if (dashingNow == true && dashing < dashLength)
        {
            Debug.Log("burda aticak");

            _movementModule.Move(dashMove * dashSpeed *Time.deltaTime);
            dashing += Time.deltaTime;
            Debug.Log("bitti" + dashMove);
        }
        if (dashing < dashLength && dashingTime < dashResetTime && dashReset == true && canDash == true)
        {
            canDash = false;
            dashReset = false;
            dashingNow = true;
        }
        if (dashing >= dashLength)
        {
            dashingNow = false;
        }

        if (dashReset == false)
        {
            dashingTime += Time.deltaTime;
        }

        if (canDash == false && dashing >= dashLength)
        {
            canDash = true;
            dashing = 0f;
        }

        if (dashingNow == false)
        {
            _movementModule.Move(dashMove * speed * Time.deltaTime);
        }

        if (dashingTime >= dashResetTime && dashReset == false)
        {
            dashReset = true;
            dashingTime = 0f;
        }
    }
}

