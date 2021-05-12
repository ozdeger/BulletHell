using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private Transform[] target;
    [SerializeField] private float speed = 20f;
    [SerializeField] private Vector3 dir;
    private int _counter = 0;

    private Transform curTarget;

    // Update is called once per frame

    private void Start()
    {     
        curTarget = target[_counter];
        curTarget = PlayerManager.Instance.Player;
    }

    void Update()
    {
        GetDir();
        transform.position += new Vector3(dir.x * Time.deltaTime * speed, dir.y * Time.deltaTime * speed, 0);

        if (Vector2.Distance(transform.position, curTarget.position) < .1f)
        {
            SwitchTarget();          
        }       
    }

    public void GetDir()
    {
        dir = (curTarget.position - transform.position).normalized;
    }

    public void SwitchTarget()
    {
        if((target.Length-1) == _counter)
        {
            _counter = -1;
        }
        _counter++;
         curTarget = target[_counter];
    }
}
