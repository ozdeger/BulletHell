using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : MonoBehaviour
{
    public void SetupMod(float health)
    {
        PlayerStatsManager.Instance.HealthBase += health;
    }
}
