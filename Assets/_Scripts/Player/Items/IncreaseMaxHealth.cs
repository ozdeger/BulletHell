using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Increase Max Health", menuName = "Items/Group1/Increase Max Health")]
public class IncreaseMaxHealth : ItemData
{
    public override void OnDrop()
    {
    }

    public override void OnPickUp()
    {
        IncreaseHealth incHealth = PlayerManager.Instance.Player.gameObject.AddComponent<IncreaseHealth>();
        incHealth.SetupMod(25);//Arttirilmak istenen health.
    }
}
