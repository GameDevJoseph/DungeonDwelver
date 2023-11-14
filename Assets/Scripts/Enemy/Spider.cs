using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
    int IDamagable.health { get ; set ; }

    public override void Init()
    {
        base.Init();
        health = base.health;
    }

    public void Damage(int damageAmount)
    {

    }
}
