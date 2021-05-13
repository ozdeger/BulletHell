using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float damage = 50f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
