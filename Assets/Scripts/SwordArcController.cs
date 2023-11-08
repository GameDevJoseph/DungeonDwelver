using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordArcController : MonoBehaviour
{
    [SerializeField] GameObject _swordArcSlash;

    public void EnableSwordArc()
    {
        _swordArcSlash.SetActive(true);
    }

    public void DisableSwordArc()
    {
        _swordArcSlash.SetActive(false);
    }
}
