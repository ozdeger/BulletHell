using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] [ShowOnly] private float _curHealth;
    [SerializeField] float maxHealth = 100f;

    [Header("Health Bar")]
    [SerializeField] private Transform bar;

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
        if (bar)
        {
            SetSize(_curHealth / maxHealth);
        }
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
