using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public bool HasKeyToCastle { get; set; }

    private void Awake()
    {
        instance = this;
    }
}
