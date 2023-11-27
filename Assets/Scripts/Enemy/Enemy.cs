using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected GameObject diamondPrefab;

    [SerializeField] protected Transform pointA, pointB;

    protected Vector3 _currentTarget;
    protected Animator _anim;
    protected SpriteRenderer _renderer;
    protected bool _turn;
    protected bool _isHit = false;
    protected bool _inCombat = false;
    protected Player _player;
    protected bool _isDead;

    public virtual void Init()
    {
        _anim = GetComponentInChildren<Animator>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _currentTarget = pointB.position;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        if (_isDead)
            return;

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !_anim.GetBool("InCombat"))
            return;

        Movement();

        
    }

    public virtual void Movement()
    {

        if (_isDead)
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


        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            _isHit = true;
            _inCombat = true;
            return;
        }

        float distanceFromPlayer = Vector3.Distance(transform.position, _player.transform.position);

        if (distanceFromPlayer > 2.0f)
        {
            _isHit = false;
            _inCombat = false;
            _anim.SetBool("InCombat", false);
        }

        if(_inCombat == false)
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);

        Vector3 direction = _player.transform.position - transform.position;

        if (_anim.GetBool("InCombat"))
            _renderer.flipX = direction.x > 0 ? false : true;
    }


    protected virtual IEnumerator SpawnDiamonds()
    {
        while (gems > 0)
        {
            var spawnedDiamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            spawnedDiamond.transform.position += new Vector3(Random.Range(-1.5f, 1.5f), 0, 0);
            gems--;
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
