using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
public class KıteAIModule : MonoBehaviour
{   
    [SerializeField] private float kiteDistance;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float min;
    [SerializeField] private float max;

    private MovementModifier _modifier;
    private IMovementModule _movementModule;
    private MovementModule _MovementModule;

    private bool isHit = false;

    Vector3 center;
    Vector3 size;

    Vector2 targetPos;


    private void Start()
    {
        _modifier = GetComponent<MovementModifier>();
        _movementModule = GetComponent<IMovementModule>();
        center = new Vector3(0, 0, 0);
        size = new Vector3(5, 3 ,0);
    }

    private void Update()
    {
        if (isHit == false)
        {
            NormalMovement();
        }
        else
        {
            HitMovement();
        }
        
    }

    private void NormalMovement()
    {
        
        Vector2 dir = Vector2.zero;

        if (Vector2.Distance(PlayerManager.Instance.Player.position, transform.position) < kiteDistance)
        {
            dir = PlayerManager.Instance.Player.position - transform.position;
            dir = -dir.normalized;
        }

        if (Vector2.Distance(PlayerManager.Instance.Player.position, transform.position) >= chaseDistance)
        {
            dir = PlayerManager.Instance.Player.position - transform.position;
            dir = dir.normalized;
        }

        if (dir != Vector2.zero)
        {
            Vector3 modifiedMovement = _modifier.ApplyMovementEffects(dir);
            _movementModule.Move(modifiedMovement);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            _MovementModule = GetComponent<MovementModule>();
            _MovementModule.setMoveSpeed(4f);
            Debug.Log("Hit");
            GetNewTargetPosition();
            isHit = true;
        }
    }

    private void HitMovement()
    {
        Vector2 dir = Vector2.zero;


        if(Vector2.Distance(targetPos, transform.position) >= .1f)
        {
            dir = targetPos - (Vector2) transform.position;
            dir = dir.normalized;
            Debug.Log("vardı");
        }
        else
        {
            GetNewTargetPosition();
        }
        if (dir != Vector2.zero)
        {
            Vector3 modifiedMovement = _modifier.ApplyMovementEffects(dir);
            _movementModule.Move(modifiedMovement);
        }
            
    }

    private void GetNewTargetPosition()
    {
        targetPos = center + new Vector3(Random.Range(-size.x, size.x), Random.Range(-size.y, size.y), 0);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(targetPos, .2f);
    }
}
