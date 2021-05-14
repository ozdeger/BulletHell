using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [Header("Health Bar Settings (Optional)")]
    [SerializeField] private HealthBar healthBar;

    private float _curHealth;

    public float CurHealth { get => _curHealth; }

    public float MaxHealth { get => maxHealth; }

    private void Start()
    {
        ResetHealth();
        UpdateHealthBar();
    }

    public void ResetHealth()
    {
        _curHealth = maxHealth;
        UpdateHealthBar();
    }

    public void DealDamage(float damage)
    {
        _curHealth -= damage;
        if(_curHealth <= 0)
        {
            Die();
        }
        UpdateHealthBar();
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

    private void UpdateHealthBar()
    {
        healthBar?.SetSize(_curHealth / maxHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
