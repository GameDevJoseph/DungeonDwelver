using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
    [SerializeField] GameObject _acidPrefab;

    int IDamagable.health { get ; set ; }

    public override void Init()
    {
        base.Init();
        health = base.health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;

        if(health < 1)
        {
            _isDead = true;
            _anim.SetTrigger("Death");
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
