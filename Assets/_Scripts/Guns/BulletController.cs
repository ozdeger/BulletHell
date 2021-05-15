using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class BulletController : MonoBehaviour
{
    private List<BulletMod> _modList = new List<BulletMod>();

    public List<BulletMod> ModList => _modList;

    private void Start()
    {
        DetectMods();
        TriggerAllModStart();
    }

    private void Update()
    {
        TriggerAllModUpdate();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerAllModHitSomething(collision.gameObject);
    }

    private void OnDestroy()
    {
        TriggerAllModHitDestroyed();
    }

    private void DetectMods()
    {
        _modList = new List<BulletMod>(GetComponents<BulletMod>());
    }


    private void TriggerAllModStart()
    {
        foreach (BulletMod mod in _modList) { mod.OnBulletStart(); }
    }

    private void TriggerAllModUpdate()
    {
        foreach (BulletMod mod in _modList) { mod.OnBulletUpdate(); }
    }

    private void TriggerAllModHitSomething(GameObject something)
    {
        foreach (BulletMod mod in _modList) { mod.OnBulletHitSomething(something); }
    }

    private void TriggerAllModHitDestroyed()
    {
        foreach (BulletMod mod in _modList) { mod.OnBulletDestroyed(); }
    }

    public static void DealDamageToTarget(Transform target, float damage)
    {
        Health healthController = target.GetComponent<Health>();

        /*HealthBar healthBar = target.GetComponent<HealthBar>();
healthBar.SetSize(healthController.CurHealth / healthController.MaxHealth);*/
        healthController.DealDamage(damage);
        
    }
}
