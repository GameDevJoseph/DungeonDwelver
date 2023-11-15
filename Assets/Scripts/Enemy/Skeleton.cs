using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
    int IDamagable.health { get ; set ; }

    public override void Init()
    {
        base.Init();
        health = base.health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        _anim.SetTrigger("Hit");

        if (health < 1)
            Destroy(this.gameObject);
    }
}
