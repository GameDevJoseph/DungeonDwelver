using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;

    [SerializeField] protected Transform pointA , pointB;

    protected Vector3 _currentTarget;
    protected Animator _anim;
    protected SpriteRenderer _renderer;
    protected bool _turn;
    
    public virtual void Init()
    {
        _anim = GetComponentInChildren<Animator>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _currentTarget = pointB.position;
    }

    public virtual void Start()
    {
        Init();
    }

    public virtual void Attack()
    {
        
    }

    public virtual void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return;

        Movement();
    }

    public virtual void Movement()
    {
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
