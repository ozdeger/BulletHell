using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDealDamage : BulletMod
{
    [SerializeField] private List<Tags> damageableTags;
    [SerializeField] private float damage;

    public override void OnBulletHitSomething(GameObject something)
    {
        if (something.TryGetComponent<Tag>(out Tag somethingsTag))
        {
            foreach (Tags tag in damageableTags)
            {
                if (somethingsTag.Tags.Contains(tag))
                {
                    BulletController.DealDamageToTarget(something.transform, damage);
                    return;
                }

            }
        }
    }

    public override void OnBulletDestroyed()
    {
    }

    public override void OnBulletUpdate()
    {
    }

    public override void OnBulletStart()
    {
    }
}
