using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveNormal : BulletMod
{
    private float _speed;

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
        GetComponent<Rigidbody2D>().AddForce(transform.right * _speed, ForceMode2D.Impulse);
    }

    public void UpdateBulletSpeed(float speed)
    {
        _speed = speed;
    }
}
