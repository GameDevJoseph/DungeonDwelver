using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] Attack _attack;

    public void ReEnableAttack()
    {
        _attack.EnableAttack();
    }
}
