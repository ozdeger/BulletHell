using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slime Chunk", menuName = "Items/Group1/Slime Chunk")]
public class SlimeChunk : ItemData
{
    [SerializeField] private GameObject trailPrefab;

    public override void OnDrop()
    {
        throw new System.NotImplementedException();
    }

    public override void OnPickUp()
    {
        BulletTrail mod = PlayerManager.Instance.BulletBlueprint.gameObject.AddComponent<BulletTrail>();
        mod.SetupMod(trailPrefab);
    }
}
