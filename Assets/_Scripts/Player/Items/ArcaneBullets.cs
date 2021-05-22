using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Arcan Bullets", menuName = "Items/Group1/Arcane Bullets")]
public class ArcaneBullets : ItemData
{
    public override void OnPickUp()
    {
        HomingBulletMod mod = PlayerManager.Instance.BulletBlueprint.gameObject.AddComponent<HomingBulletMod>();
        mod.SetupMod(3, 3);
    }

    public override void OnDrop()
    {
        //
    }
}
