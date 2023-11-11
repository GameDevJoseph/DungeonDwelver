using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{

    bool _switch;
    void Start()
    {
        Attack();
    }

    public override void Attack()
    {
        base.Attack();
    }

    public override void Update()
    {
        if(transform.position == pointA.position)
            _switch = true;

        if (transform.position == pointB.position)
            _switch = false;

        if(_switch)
            transform.position = Vector3.MoveTowards(transform.position,pointB.position, speed * Time.deltaTime);

        if(!_switch)
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
    }
}
