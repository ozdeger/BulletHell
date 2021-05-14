using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveNormal : BulletMod
{
    [SerializeField] private float speed;

    public override void OnBulletDestroyed()
    {
    }

    public override void OnBulletFixedUpdate()
    {
    }

    public override void OnBulletHitSomething(GameObject something)
    {
    }

    public override void OnBulletStart()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Impulse);
    }
}
