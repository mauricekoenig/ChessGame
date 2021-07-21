

using UnityEngine;

namespace MauriceKoenig.ChessGame {

    [RequireComponent(typeof(Mover))]
    public sealed class Controller : MonoBehaviour
    {
        private Mover LocalMover { get; set; }

        private void Start() {

            LocalMover = GetComponent<Mover>();
        }
        private void OnMouseDown() {

            LocalMover.PrepareMovement();
        }
        private void OnMouseDrag() {

            LocalMover.ExecuteMovement();
        }
        private void OnMouseUp() {

            LocalMover.AnalyseMovement();
        }
    }
}