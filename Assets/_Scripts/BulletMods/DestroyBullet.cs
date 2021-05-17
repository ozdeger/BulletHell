using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : BulletMod
{
    public override void OnBulletDestroyed()
    {
    }

    public override void OnBulletFixedUpdate()
    {
    }

    public override void OnBulletHitSomething(GameObject something)
    {
        if (something.TryGetComponent<Tag>(out Tag somethingsTag))
        {
            if (somethingsTag.Tags.Contains(Tags.Obstacle))
            {
                Destroy(gameObject);
            }

            if (somethingsTag.Tags.Contains(Tags.Enemy))
            {
                Destroy(gameObject);
            }
        }
    }

    public override void OnBulletStart()
    {
    }
}
