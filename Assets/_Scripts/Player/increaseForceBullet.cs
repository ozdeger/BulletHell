using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseForceBullet : MonoBehaviour
{
    private IAim _increaseForce;



    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _increaseForce = collision.GetComponent<Aim>();
            _increaseForce.increaseBulletForce();
        }
        
    }


}
