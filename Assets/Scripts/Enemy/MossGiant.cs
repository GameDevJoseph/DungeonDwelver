using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamagable
{
    int IDamagable.health { get ; set; }

    public override void Init()
    {
        base.Init();
        health = base.health;
    }

    public void Damage(int damageAmount)
    {
        Debug.Log("Damaged");
    }

}
