using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    Vector3 _currentTarget;
    bool _turn;

    Animator _anim;
    SpriteRenderer _renderer;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _currentTarget = pointB.position;
        Attack();
    }

    public override void Attack()
    {
        base.Attack();
    }

    public override void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("MossGiantIdle_anim"))
            return;

        var distance = Vector3.Distance(transform.position, _currentTarget);
        _renderer.flipX = _currentTarget == pointA.position ? true : false;

        if (distance <= 1f)
        {
            _anim.SetTrigger("Idle");
            _turn = !_turn;
        }

        if (_turn)
            _currentTarget = pointA.position;

        if (!_turn)
            _currentTarget = pointB.position;

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
