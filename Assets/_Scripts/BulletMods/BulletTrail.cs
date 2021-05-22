using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : BulletMod
{
    [SerializeField] private GameObject trailPrefab;

    public void SetupMod(GameObject trailPrefab_)
    {
        trailPrefab = trailPrefab_;
    }

    public override void OnBulletDestroyed()
    {
    }

    public override void OnBulletFixedUpdate()
    {
        Transform summon = Instantiate(trailPrefab).transform;
        summon.position = transform.position;
        summon.right = transform.right;
    }

    public override void OnBulletHitSomething(GameObject something)
    {
    }

    public override void OnBulletStart()
    {
    }
}
