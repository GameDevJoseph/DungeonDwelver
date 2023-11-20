using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAcidEvent : MonoBehaviour
{

    Spider _spider;

    private void Start()
    {
        _spider = GetComponentInParent<Spider>();
    }

    [SerializeField] GameObject _acidPrefab;
    public void FireAcid()
    {
        _spider.Attack();
    }
}
