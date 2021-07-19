


using System;
using UnityEngine;


public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance;
    public ColorField CurrentPlayer { get; private set; } = ColorField.White;
    public int TurnCounter { get; set; } = 0;

    private void Awake () {

        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}