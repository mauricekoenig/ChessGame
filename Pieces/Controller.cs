

using UnityEngine;

namespace MauriceKoenig.ChessGame {

    [RequireComponent(typeof(Mover))]
    public sealed class Controller : MonoBehaviour
    {
        private BasePiece Piece { get; set; } // noch nicht benutzt?
        private Mover PieceMover { get; set; }

        private void Start() {

            Piece = GetComponent<BasePiece>();
            PieceMover = GetComponent<Mover>();
        }

        private void OnMouseDown() {

            PieceMover.PrepareMovement();
        }
        private void OnMouseDrag() {

            PieceMover.ExecuteMovement();
        }
        private void OnMouseUp() {

            PieceMover.AnalyseMovement();
        }

    }
}