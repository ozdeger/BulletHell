using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Utilities;
public class HomingBulletMod : BulletMod
{

    [SerializeField] private float range;
    [SerializeField] private float homingSpeed;

    private List<Transform> _targetsInRange = new List<Transform>();
    private Rigidbody2D _rb;

    public override void OnBulletDestroyed()
    {

    }

    public override void OnBulletHitSomething(GameObject something)
    {

    }

    public override void OnBulletStart()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void OnBulletFixedUpdate()
    {
        Collider2D[] everythingInRange = Physics2D.OverlapCircleAll(transform.position, range);

        _targetsInRange.Clear();

        foreach (Collider2D curCollider in everythingInRange)
        {
            if (curCollider.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Enemy))//Enemy tagi ise yaz
            {
                _targetsInRange.Add(curCollider.transform);
            }
        }

        Transform closestTarget = UsefulStaticFunctions.GetClosestEnemy(transform.position, _targetsInRange);

        if (closestTarget) 
        { 
            Vector2 homingDir = (closestTarget.position - transform.position).normalized; 
            _rb.AddForce(homingDir * homingSpeed, ForceMode2D.Impulse);
        }
        

        

    }

    private void OnDrawGizmos()
    {
        Handles.DrawWireDisc(transform.position, transform.forward, range);
    }

}
