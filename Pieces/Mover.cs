

using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace MauriceKoenig.ChessGame
{
    public sealed class Mover : MonoBehaviour
    {
        private BasePiece Piece { get; set; }
        private PieceBehaviour Behaviour { get; set; }
        private Camera MainCam { get; set; }
        private Vector3 Origin { get; set; }
        private bool IsDragging { get; set; }
        private List<Square> _validMoves = new List<Square>();
        private bool LocalPermission => GameManager.Instance.CurrentPlayer == Piece.ColorProperty;
        [SerializeField] private Square Scan { get; set; }

        private void Start() {

            this.MainCam = Camera.main;
            this.Piece = GetComponent<BasePiece>();
            this.Behaviour = GetComponent<PieceBehaviour>();
        }
        public void PrepareMovement() {

            if (!Security.GlobalPermission) return;
            if (!IsDragging && LocalPermission) {

                this.IsDragging = true;
                this.Origin = this.transform.position;
                this.ComparisonCoordinates = this.Piece.Coordinates;
                this._validMoves.Clear();
                this._validMoves = this.Behaviour.GetValidMoves();

                DisableRaycastProperty();
                EnableHighlighting();
            }
        }
        public void ExecuteMovement() {

            if (IsDragging && LocalPermission) {
                transform.position = GetWorldPosition(transform);
                Debug.DrawRay(transform.position, Vector3.forward * 100);
                if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit rayHit)) {
                    if (rayHit.collider.GetComponent<Square>()) {
                        Scan = rayHit.collider.GetComponent<Square>();
                    }
                } else Scan = null;
            }
        }
        public void AnalyseMovement() {

            while (IsDragging) {

                if (Scan == null) {
                    DisableDraggingFlag();
                    SendBackOrigin();
                    ResetRaycast();
                    break;
                } else {

                    var MoveIsValid = _validMoves.Contains(Scan);

                    if (!MoveIsValid) {
                        DisableDraggingFlag();
                        SendBackOrigin();
                        ResetRaycast();
                        break;
                    } else {

                        if (Scan.CurrentSubscriber == null) {
                            Piece.UnderlyingSquare.RemoveSubscriber();
                            Scan.AddSubscriber(Piece);

                            PawnFlag_HasMovedAlready(Piece);
                            PawnFlag_MovedTwoSquares(Piece);
                            PawnFlag_DisableEnPassantProperty();
                            PawnFlag_Recruitment(Piece);

                            ResetRaycast();
                            DisableDraggingFlag();
                            SetInternalPieceCounter();
                            break;
                        } else if (Scan.CurrentSubscriber != null) {

                            Capture(Scan, Piece);

                            PawnFlag_HasMovedAlready(Piece);
                            PawnFlag_MovedTwoSquares(Piece);
                            PawnFlag_DisableEnPassantProperty();
                            PawnFlag_Recruitment(Piece);

                            ResetRaycast();
                            DisableDraggingFlag();
                            SetInternalPieceCounter();
                            break;
                        }
                    }
                }
            }

            DisableHighlighting();
            EnableRaycastProperty();
        }
        private void Capture(Square square, BasePiece piece) {

            piece.UnderlyingSquare.RemoveSubscriber();
            Board.Instance.Pieces.Remove(square.CurrentSubscriber);
            Destroy(square.CurrentSubscriber.gameObject);
            square.RemoveSubscriber();
            square.AddSubscriber(piece);
        }
        private void EnableRaycastProperty() {

            foreach (var element in Board.Instance.Pieces.Where(x => x != Piece)) {

                element.gameObject.layer = 10;
            }
        }
        private void DisableRaycastProperty() {

            foreach (var element in Board.Instance.Pieces.Where(x => x != Piece)) {

                element.gameObject.layer = 2;
            }
        }
        private void DisableDraggingFlag() {

            IsDragging = false;
        }
        private void SendBackOrigin() {

            this.transform.position = Origin;
        }
        private void ResetRaycast() {

            Scan = null;
        }
        private void EnableHighlighting() {

            if (_validMoves.Count > 0) {

                foreach (var sq in _validMoves) {

                    sq.EnablePreviewGraphic();
                }
            }
        }
        private void DisableHighlighting() {

            if (_validMoves.Count > 0) {

                foreach (var sq in _validMoves) {

                    sq.DisablePreviewGraphic();
                }
            }
        }
        private void SetInternalPieceCounter() {

            this.Piece.InternalTurnCounter = 0;
            this.Piece.InternalTurnCounter += GameManager.Instance.GlobalTurnCounter;
        }
        private Vector3 GetWorldPosition(Transform transform) {

            var desiredPosition = MainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, MainCam.nearClipPlane));
            return desiredPosition;
        }

        [PawnFlag] private Vector2 ComparisonCoordinates { get; set; }
        [PawnFlag] private void PawnFlag_HasMovedAlready(BasePiece piece) {

            if (piece.GetType() == typeof(Pawn)) {

                var pawn = piece as Pawn;
                pawn.HasNotMoved = false;
            }
        }
        [PawnFlag] private void PawnFlag_MovedTwoSquares(BasePiece piece) {

            if (piece.GetType() == typeof(Pawn)) {
                var pawn = this.Piece as Pawn;
                if (pawn.HasMovedTwoFields) return;
                if (pawn.Coordinates.y == (this.ComparisonCoordinates.y + 2) || pawn.Coordinates.y == (this.ComparisonCoordinates.y - 2)) {
                    pawn.HasMovedTwoFields = true;
                    this.ComparisonCoordinates = Vector2.zero;
                } else {
                    pawn.HasMovedTwoFields = false;
                    this.ComparisonCoordinates = Vector2.zero;
                }
            }
        }
        [PawnFlag] private void PawnFlag_DisableEnPassantProperty() {

            if (this.Piece.GetType() == typeof(Pawn)) {
                var pawn = this.Piece as Pawn;
                pawn.CanBeCapturedEnPassant = false;
            }
        }
        [PawnFlag] private void PawnFlag_Recruitment(BasePiece piece) {

            if (piece.GetType() != typeof(Pawn)) {

                GameManager.Instance.ChangeActivePlayer();
                return;
            }

            var pawn = piece as Pawn;

            if (pawn.ColorProperty == ColorProperty.White) {
                if (pawn.Coordinates.y == 8) {
                    Security.Lock();
                    GameUIManager.Instance.ShowPieces(gameObject, this.Piece);
                    return;
                } else GameManager.Instance.ChangeActivePlayer();
            } else if (pawn.ColorProperty == ColorProperty.Black) {
                if (pawn.Coordinates.y == 1) {
                    Security.Lock();
                    GameUIManager.Instance.ShowPieces(gameObject, this.Piece);
                    return;
                } else GameManager.Instance.ChangeActivePlayer();
            }

            return;
        }
    }
}