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

    private void FixedUpdate()
    {
        TriggerAllModFixedUpdate();
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

    private void TriggerAllModFixedUpdate()
    {
        foreach (BulletMod mod in _modList) { mod.OnBulletFixedUpdate(); }
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
        healthController.DealDamage(damage);
    }
}
