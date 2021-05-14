using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public abstract class BulletMod : MonoBehaviour
{
    public abstract void OnBulletDestroyed();

    public abstract void OnBulletUpdate();

    public abstract void OnBulletHitSomething(GameObject something);

    public abstract void OnBulletStart();
}
