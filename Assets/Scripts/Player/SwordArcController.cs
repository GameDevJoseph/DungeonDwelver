using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordArcController : MonoBehaviour
{
    [SerializeField] GameObject _swordArcSlash;
    [SerializeField] Attack _attack;

    public void EnableSwordArc()
    {
        _swordArcSlash.SetActive(true);
    }

    public void DisableSwordArc()
    {
       _attack.EnableAttack();
       _swordArcSlash.SetActive(false);
    }

   
}
