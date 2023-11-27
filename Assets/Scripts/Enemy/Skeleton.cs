using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
    int IDamagable.health { get; set; }

    public override void Init()
    {
        base.Init();
        health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage(int damageAmount)
    {
        if (_isDead)
            return;

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            return;

        health -= damageAmount;

        _anim.SetBool("InCombat", true);
        _anim.SetTrigger("Hit");

        if (health < 1)
        {
            _isDead = true;
            _anim.SetTrigger("Death");
            StartCoroutine(SpawnDiamonds());
        }
    }
}
