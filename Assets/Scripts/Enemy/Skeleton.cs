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

        Vector3 direction = _player.transform.position - transform.position;

        if(_anim.GetBool("InCombat"))
            _renderer.flipX = direction.x > 0 ? false : true;
    }

    public void Damage(int damageAmount)
    {
        if (_isHit)
            return;

        health -= damageAmount;

        _anim.SetBool("InCombat", true);
        _anim.SetTrigger("Hit");

        if (health < 1)
            Destroy(this.gameObject);
    }
}
