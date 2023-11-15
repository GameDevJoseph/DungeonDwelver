using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //variable to determine if damage can be called
    bool _hasHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_hasHit)
            return; 

        Debug.Log("Hit " + collision.name);

        IDamagable hit = collision.GetComponent<IDamagable>();

        if (hit != null)
        {
            hit.Damage(5);
            _hasHit = true;
        }
    }

    public void EnableAttack()
    {
        _hasHit = false;
    }
}
