using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;

    private float _curHealth;

    public float CurHealth { get => _curHealth; }

    public float MaxHealth { get => maxHealth; }

    private void Start()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        _curHealth = maxHealth;
    }

    public void DealDamage(float damage)
    {
        _curHealth -= damage;
        if(_curHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void ChangeHealth(float _health)
    {
        
        _curHealth = _health;
    }

    public void HealthRegen()
    {
        if(_curHealth < maxHealth )
        {
            _curHealth += 5f;
        }

        if (_curHealth > maxHealth)
        {
            _curHealth = maxHealth;
        }
    }
    
    public void HealthRegenUpgrade()
    {
        InvokeRepeating(nameof(HealthRegen), 2.0f, 0.1f);
    }

}
