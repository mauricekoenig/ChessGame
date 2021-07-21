


using System;
using UnityEngine;


namespace MauriceKoenig.ChessGame
{
    [Singleton]
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public ColorProperty CurrentPlayer { get; private set; } = ColorProperty.White;
        public int GlobalTurnCounter { get; private set; } = 0;

        private void Awake() {

            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }
        public void ChangeActivePlayer() {

            CurrentPlayer = 
            CurrentPlayer == ColorProperty.Black ? 
            ColorProperty.White : ColorProperty.Black;
        }
    }
}