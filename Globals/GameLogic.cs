


using System;
using UnityEngine;


public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance;
    public ColorField CurrentPlayer { get; private set; } = ColorField.White;
    public event Action OnPlayerPlayedTurn;

    private void Awake () {

        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        OnPlayerPlayedTurn += ChangeCurrentPlayer;
    }
    public void InvokeOnPlayerPlayedTurn() {

        OnPlayerPlayedTurn.Invoke();
    }
    public void ChangeCurrentPlayer () {

        if (CurrentPlayer == ColorField.Black) CurrentPlayer = ColorField.White;
        else if (CurrentPlayer == ColorField.White) CurrentPlayer = ColorField.Black;
    }
}