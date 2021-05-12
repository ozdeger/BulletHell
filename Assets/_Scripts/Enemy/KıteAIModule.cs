using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KıteAIModule : MonoBehaviour
{
    private MovementModifier _modifier;
    private IMovementModule _movementModule;
    [SerializeField] private float kiteDistance;
    [SerializeField] private float chaseDistance;

    private void Start()
    {
        _modifier = GetComponent<MovementModifier>();
        _movementModule = GetComponent<IMovementModule>();
    }

    private void Update()
    {
        Vector2 dir = Vector2.zero;

        if(Vector2.Distance(PlayerManager.Instance.Player.position, transform.position) < kiteDistance)
        {
            dir = PlayerManager.Instance.Player.position - transform.position;
            dir = -dir.normalized;
        }

        if(Vector2.Distance(PlayerManager.Instance.Player.position, transform.position) >= chaseDistance)
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
}
