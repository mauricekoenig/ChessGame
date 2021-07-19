


using System;
using UnityEngine;


public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance;
    public ColorField CurrentPlayer { get; private set; } = ColorField.White;
    public int TurnCounter { get; private set; } = 0;
    public int Turn_Counter;

    private void Awake () {

        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    protected void Update() {
        Turn_Counter = TurnCounter;
    }

    public void ChangeActivePlayer() {

        if (CurrentPlayer == ColorField.Black) {
                CurrentPlayer = ColorField.White;
                    TurnCounter++;
        } 

        else if (CurrentPlayer == ColorField.White) {
            CurrentPlayer = ColorField.Black;
                TurnCounter++;
        }
    }
}