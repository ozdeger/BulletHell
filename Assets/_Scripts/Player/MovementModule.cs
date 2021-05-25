using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModule : MonoBehaviour, IMovementModule
{
    private float _moveSpeed;

    private Rigidbody2D _rb;

    private bool _active = true;
    private Vector2 _dir;

    private IEnumerator coroutine;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_active)
        {
            _rb.MovePosition(_rb.position + _dir * _moveSpeed * Time.fixedDeltaTime);
            _dir = Vector2.zero;
        }
    }

    public void Sprint()
    {
        _moveSpeed = _moveSpeed * 2;
        coroutine = IncreaseSpeed(3.0f);
        StartCoroutine(coroutine);
    }

    private IEnumerator IncreaseSpeed(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _moveSpeed = _moveSpeed / 2;
    }

    public void setMoveSpeed(float increaseSpeed)
    {
        _moveSpeed = increaseSpeed;
    }

    public void Move(Vector2 dir)
    {
        _dir = dir;
    }

    public void UpdateMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
