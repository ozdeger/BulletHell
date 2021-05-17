using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class SpeedEffect : MonoBehaviour, IMovementEffect
{
    [SerializeField] private bool isTemporary = false;
    [SerializeField] private Cooldown coolDown;
    [SerializeField] private float multiplier = 2f;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (isTemporary)
        {
            coolDown.Step(Time.deltaTime);

            if (coolDown.IsReady)
            {
                Destroy(this);
            }
        } 
    }

    public Vector2 Modify(Vector2 movementVector)
    {
        return movementVector * multiplier;
    }
}
