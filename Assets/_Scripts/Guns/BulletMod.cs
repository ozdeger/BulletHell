using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public abstract class BulletMod : MonoBehaviour
{
    //protected virtual void Awake()
    //{
    //    if (TryGetComponent<BulletController>(out BulletController bulletController))
    //    {
    //        bulletController.ModList.Add(this);
    //    }
    //}

    public abstract void OnBulletDestroyed();

    public abstract void OnBulletFixedUpdate();

    public abstract void OnBulletHitSomething(GameObject something);

    public abstract void OnBulletStart();
}
