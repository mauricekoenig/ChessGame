


using System.Collections.Generic;
using UnityEngine;

namespace MauriceKoenig.ChessGame
{
    [BaseClass]
    public abstract class PieceBehaviour : MonoBehaviour
    {
        protected BasePiece piece;
        protected List<Square> validSquares = new List<Square>();

        protected virtual void Start() {

            piece = GetComponent<BasePiece>();
        }
        public abstract List<Square> GetValidMoves();
    }
}