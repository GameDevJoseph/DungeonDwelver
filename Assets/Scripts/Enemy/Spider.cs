using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
    [SerializeField] GameObject _acidPrefab;

    int IDamagable.Health { get ; set ; }

    public override void Init()
    {
        base.Init();
        health = base.health;
    }

    public void Damage(int damageAmount)
    {
        if (_isDead)
            return;

        health -= damageAmount;

        if(health < 1)
        {
            _isDead = true;
            _anim.SetTrigger("Death");
            StartCoroutine(SpawnDiamonds());
        }
    }

    public override void Update()
    {
       
    }

    public override void Movement()
    {
        
    }

    public override void Attack()
    {
        Instantiate(_acidPrefab, transform.position, Quaternion.identity);
    }
}
