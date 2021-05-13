using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModule : MonoBehaviour, IMovementModule
{
    [SerializeField] private float moveSpeed = 2f;

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
            _rb.MovePosition(_rb.position + _dir * moveSpeed * Time.fixedDeltaTime);
            _dir = Vector2.zero;
        }
    }

    public void Sprint()
    {
        moveSpeed = moveSpeed * 2;
        coroutine = IncreaseSpeed(3.0f);
        StartCoroutine(coroutine);
    }

    private IEnumerator IncreaseSpeed(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        moveSpeed = moveSpeed / 2;
    }

    public void setMoveSpeed(float increaseSpeed)
    {
        moveSpeed = increaseSpeed;
    }


    public void Move(Vector2 dir)
    {
        _dir = dir;
    }

    
}
