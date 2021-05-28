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
    private Health _healthModule;
    private bool isDashing = false;
    private Vector2 moveStep;

    public bool IsDashing { get => isDashing; }
    public float DashSeconds { get => dashSeconds; }

    private void Start()
    {
        movementModule = GetComponent<IMovementModule>();
        _healthModule = GetComponent<Health>();
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

            _healthModule.CheckInvincible(calculatedDashSeconds);
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
