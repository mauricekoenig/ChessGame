


using System;
using UnityEngine;


public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance;
    public ColorField CurrentPlayer { get; private set; } = ColorField.White;
    public int TurnCounter { get; private set; } = 0;

    private void Awake () {

        if (Instance == null) Instance = this;
        else Destroy(gameObject);
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
    public void InitializeRecruiting() {

        Security.Lock();
    }
}