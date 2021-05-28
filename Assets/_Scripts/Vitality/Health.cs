using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] [ShowOnly] private float _curHealth;
    [SerializeField] float _maxHealth;

    [Header("Health Bar")]
    [SerializeField] private Transform bar;


    [SerializeField] private bool _isInvincible = false;

    //public bool IsInvincible { get => _isInvincible; }

    public float CurHealth { get => _curHealth; }

    public float MaxHealth { get => _maxHealth; }


    private void Start()
    {
        
        ResetHealth();
        UpdateHealthBar();
    }

    public void ResetHealth()
    {
        _curHealth = _maxHealth;
        UpdateHealthBar();
    }

    public void DealDamage(float damage)
    {
        if (!_isInvincible)
        {
            _curHealth -= damage;
            if(_curHealth <= 0)
            {
                Die();
            }
            UpdateHealthBar();
        }
        
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

    public void WhileDashing()
    {
        _isInvincible = true;
    }

    public void CheckInvincible(float DashSeconds)
    {
        WhileDashing();
        if (_isInvincible)
        {
            Invoke(nameof(StopInvincible), DashSeconds);
        }
    }

    private void StopInvincible()
    {
        _isInvincible = false;
    }
}
