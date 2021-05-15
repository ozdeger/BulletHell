using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBurst : BulletMod
{
    [SerializeField] private float speed;


    public override void OnBulletDestroyed()
    {

    }

    public override void OnBulletHitSomething(GameObject something)
    {

    }

    public override void OnBulletStart()
    {
        
        StartCoroutine(Burst());
    }

    public override void OnBulletUpdate()
    {  
    }
    IEnumerator Burst()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

}
