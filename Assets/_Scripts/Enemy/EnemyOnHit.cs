using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnHit : MonoBehaviour
{

    [SerializeField] private float min;
    [SerializeField] private float max;
    private MovementModule _movementModule;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("here");
        if(collision.gameObject.tag == "Obstacle")
        {
            _movementModule = GetComponent<MovementModule>();
            _movementModule.setMoveSpeed(4f);
        }
    }

    private Vector3 RandomVector()
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        return new Vector3(x, y, 0);
    }
}
