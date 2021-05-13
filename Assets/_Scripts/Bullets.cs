using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float damage = 50f;

    private HealthBar _healthBar;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        var health = collision.GetComponent<Health>();
        _healthBar = collision.GetComponent<HealthBar>();


        health.DealDamage(damage);
        _healthBar.SetSize(health.CurHealth / health.MaxHealth);
    }
}
