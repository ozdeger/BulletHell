using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class DetectEnemy : MonoBehaviour
{
    public float range = 100f;

    private void Update()
    {
        Cast();

    }

    private void Cast()
    {
        
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, range, LayerMask.NameToLayer("Default"));
        Debug.Log("Found " + enemiesInRange.Length + " enemies in range.");
    }

}
