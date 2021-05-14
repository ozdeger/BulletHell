using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WonderAiInutModule : MonoBehaviour
{
    [SerializeField] private float wonderRange;

    private Vector2 wonderAnchor;
    private MovementModifier _movementModifier;
    private IMovementModule _movementModule;
    private Vector2 curRandomTargetPos;

    private void Start()
    {
        _movementModule = GetComponent<MovementModule>();
        _movementModifier = GetComponent<MovementModifier>();
        wonderAnchor = transform.position;
        GenerateRandomPosition();
    }

    private void FixedUpdate()
    {
        if (((Vector2)transform.position - curRandomTargetPos).magnitude > .3f)
        {
            _movementModule.Move((curRandomTargetPos - (Vector2)transform.position).normalized);
        }
        else
        {
            GenerateRandomPosition();
        }
    }

    private void GenerateRandomPosition()
    {
        curRandomTargetPos = wonderAnchor + Random.insideUnitCircle * wonderRange;
    }

    private void OnDrawGizmos() 
    {
        if (wonderAnchor == Vector2.zero) return;
        Handles.DrawWireDisc(wonderAnchor, new Vector3(0, 0, 1), wonderRange);
    }
}
