using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedEffect : MonoBehaviour, IMovementEffect
{

    [Serializable]
    private struct Cooldown
    {
        public float cooldown;
        private float timer;

        public bool IsReady
        {
            get { if (timer >= cooldown) { return true; } else { return false; } }
        }

        public Cooldown(float _cooldown)
        {
            cooldown = _cooldown;
            timer = _cooldown;
        }

        public void Step(float deltaTime)
        {
            if (timer < cooldown)
            {
                timer += deltaTime;
            }
        }

        public void EnterCooldown()
        {
            timer = 0;
        }
    }

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
        Debug.Log("multiplier: "+multiplier.ToString());
        return movementVector * multiplier;
    }
}
