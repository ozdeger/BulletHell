using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class DashModule : MonoBehaviour, IDashModule
{
    [Header("Temporary")]
    [SerializeField] private float movementSpeed;
    [Header("Options")]
    [SerializeField] private float dashDistance;
    [SerializeField] private float dashSeconds;
    [SerializeField] private Cooldown dashCooldown;

    private IMovementModule movementModule;
    private bool isDashing = false;
    private Vector2 moveStep;

    public bool IsDashing { get => isDashing; }

    private void Start()
    {
        movementModule = GetComponent<IMovementModule>();
    }

    private void FixedUpdate()
    {
        dashCooldown.Step(Time.fixedDeltaTime);

        if (isDashing)
        {
            Dash();
        }
    }

    public void DoDash(Vector2 dir)
    {
        if (dashCooldown.IsReady)
        {
            dashCooldown.EnterCooldown();
            isDashing = true;

            float calculatedDashSeconds = dashSeconds / movementSpeed;
            float distanceStep = dashDistance / ((calculatedDashSeconds));
            moveStep = distanceStep * dir;

            Invoke(nameof(StopDash), calculatedDashSeconds);
        }
    }

    private void Dash()
    {
        movementModule.Move(moveStep);
    }

    private void StopDash()
    {
        isDashing = false;
    }
}
