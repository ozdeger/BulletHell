using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Monitors")]
    [SerializeField] [ShowOnly] private float _curHealth;
    [SerializeField] [ShowOnly] private int _isInvincible = 0;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _invincibleWindow;

    [Header("Health Bar")]
    [SerializeField] private Transform bar;

    //public bool IsInvincible { get => _isInvincible; }

    public float CurHealth { get => _curHealth; }

    public float MaxHealth { get => _maxHealth; }


    private void Start()
    {     
        ResetHealth();
    }

    public void ResetHealth()
    {
        _curHealth = _maxHealth;
        UpdateHealthBar();
    }

    public void DealDamage(float damage)
    {
        if (_isInvincible != 0)  return;

        _curHealth -= damage;
        if (_curHealth <= 0)
        {
            Die();
        }
        UpdateHealthBar();

        TurnInvincible(_invincibleWindow);
    }

    public void HealthRegen()
    {
        if(_curHealth < _maxHealth )
        {
            _curHealth += 5f;
        }

        if (_curHealth > _maxHealth)
        {
            _curHealth = _maxHealth;
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
            SetSize(_curHealth / _maxHealth);
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

    public void UpdateMaxHealth(float maxHealth)
    {
        _curHealth += maxHealth - _maxHealth;
        _maxHealth = maxHealth;
    }

    public void TurnInvincible(float DashSeconds)
    {
        _isInvincible += 1;
        Invoke(nameof(StopInvincible), DashSeconds);     
    }

    private void StopInvincible()
    {
        _isInvincible -= 1;
    }
}
