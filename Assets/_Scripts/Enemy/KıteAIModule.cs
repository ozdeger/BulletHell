using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
public class KıteAIModule : MonoBehaviour
{   

    [SerializeField] private float kiteDistance;
    [SerializeField] private float chaseDistance;

    [SerializeField] private float tempSetMoveSpeed;

    private MovementModifier _modifier;
    private IMovementModule _movementModule;
    private MovementModule _MovementModule;

    private List<Transform> _targetsInRange = new List<Transform>();

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
        CheckAround();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            _MovementModule = GetComponent<MovementModule>();
            _MovementModule.setMoveSpeed(tempSetMoveSpeed);

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

    private void CheckAround()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 2f,Vector2.zero);

        _targetsInRange.Clear();

        foreach(RaycastHit2D closestEbj in hit)
        {
            if (!closestEbj.collider.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Enemy))
            {
                Debug.DrawLine(transform.position, closestEbj.point, Color.red);
                //Debug.Log((transform.position - closestEbj.collider.gameObject.transform.position).normalized);
                Debug.Log("Etrafımda biri var");
                _targetsInRange.Add(closestEbj.transform);
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + transform.right * 2f, Color.green);
            }
        }

        Transform closestTarget = UsefulStaticFunctions.GetClosestEnemy(transform.position, _targetsInRange);
        Debug.Log(closestTarget.gameObject.name);

        if (closestTarget)
        {
            Vector2 homingDir = (transform.position - closestTarget.position).normalized;

            if (Vector2.Distance(transform.position, closestTarget.position) >= 2f)
            {
                homingDir = -homingDir.normalized;          
            }

            if (homingDir != Vector2.zero)
            {
                Debug.Log("Moving");
                //homingDir = -homingDir.normalized;

                Vector3 modifiedMovement = _modifier.ApplyMovementEffects(homingDir);
                _movementModule.Move(modifiedMovement);
            }
        }
    }
}
