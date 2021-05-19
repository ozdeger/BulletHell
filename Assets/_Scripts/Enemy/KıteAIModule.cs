using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using System;


public class KıteAIModule : MonoBehaviour
{   
    
    [Header("Options")]
    [SerializeField] private float kiteDistance;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float tempSetMoveSpeed;

    private MovementModifier _modifier;
    private IMovementModule _movementModule;
    private MovementModule _MovementModule;

    private Collider2D _collider;  
    private float obstacleMultiplier;
    private Vector2 dir;
    private Vector2 colliderCenter;
    private Vector2 obstacleCenterDir = Vector2.zero;

    private Vector2[] _raycastDirections =
    {
        new Vector2(0,1),
        new Vector2(0.7f,0.7f),
        new Vector2(1,0),
        new Vector2(0.7f,-0.7f),
        new Vector2(0,-1),
        new Vector2(-0.7f,-0.7f),
        new Vector2(-1,0),
        new Vector2(-0.7f,0.7f),              
    };
    
    Vector2 targetPos;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _modifier = GetComponent<MovementModifier>();
        _movementModule = GetComponent<IMovementModule>();

        InvokeRepeating(nameof(CheckAround), 0, .1f);
    }

    private void Update()
    {
        NormalMovement();
    }

    private void NormalMovement()
    {
        dir = Vector2.zero;

        if (Vector2.Distance(PlayerManager.Instance.Player.position, transform.position) >= chaseDistance)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, obstacleCenterDir, 2f);
            DetermineDirection(1, hit);
        }

        if (Vector2.Distance(PlayerManager.Instance.Player.position, transform.position) < kiteDistance)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, obstacleCenterDir, 2f);
            DetermineDirection(-1, hit);
        }

        if (dir.sqrMagnitude > .01f)
        {
            Debug.Log(dir.sqrMagnitude);
            dir.Normalize();
            Debug.DrawLine(transform.position, (Vector2)transform.position + (dir * 3f), Color.magenta);
            Vector3 modifiedMovement = _modifier.ApplyMovementEffects(dir);
            _movementModule.Move(modifiedMovement);
        }
    }

    private void DetermineDirection(float multiplierDir, RaycastHit2D hit)
    {
        dir = (PlayerManager.Instance.Player.position - transform.position).normalized;
        dir = (multiplierDir * dir / 2 - obstacleCenterDir * (1 - (hit.distance / 2)));
    }

    private void CheckAround()
    {
        colliderCenter = _collider.bounds.center;
        obstacleCenterDir = Vector2.zero;

        List<Vector2> hitDirections = new List<Vector2>();
        for (int i = 0; i < _raycastDirections.Length; i++)
        {
            //Debug.DrawLine(colliderCenter, (Vector2)colliderCenter + (_raycastDirections[i] * 2f), Color.red,.1f);
            RaycastHit2D[] hitResults = UsefulStaticFunctions.Raycast2DWithIgnore(colliderCenter, _raycastDirections[i], 2f, gameObject);
            foreach(RaycastHit2D hit in hitResults)
            {
                if(hit.collider.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Obstacle))
                {
                    //Debug.DrawLine(colliderCenter, (Vector2)colliderCenter + (_raycastDirections[i] * 2f), Color.green,.1f);
                    hitDirections.Add(_raycastDirections[i]);
                }             
            }                
        }      

        foreach(Vector2 dir in hitDirections)
        {
            obstacleCenterDir += dir;
        }
        obstacleCenterDir.Normalize();
        //Debug.DrawLine(colliderCenter, (Vector2)colliderCenter + (obstacleCenterDir * 3f), Color.magenta);
    }
}
