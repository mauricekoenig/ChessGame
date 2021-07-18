

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class PieceMover : MonoBehaviour
{

    [SerializeField] private Square square;
    private Piece piece;
    private PieceBehaviour pieceBehaviour;
    private Camera mainCam;

    [SerializeField] private List<Square> validMoves = new List<Square>();
    public bool HasPermissionToMove { get { return GameLogic.Instance.CurrentPlayer == piece.ColorProperty; } private set { } }

    // Inspector Helper
    public bool PERMISSION;

    // REMOVE HELPER SOON
    private void Update() {

        PERMISSION = HasPermissionToMove;
    }

    private Vector3 origin;
    [SerializeField] private bool isDragging;

    private void Start () {

        this.mainCam = Camera.main;
        this.piece = GetComponent<Piece>();
        this.pieceBehaviour = GetComponent<PieceBehaviour>();
    }

    internal void PrepareDragging() {

        if (!isDragging && HasPermissionToMove) {

            this.isDragging = true;
            this.origin = this.transform.position;
            this.validMoves.Clear();
            this.validMoves = this.pieceBehaviour.GetValidMoves();
            ApplyIgnoreRaycastLayerToAllPieces();
            EnableVisibilityOfPossibleMoves();
        }
    }
    internal void DragAndRaycast() {

        if (isDragging && HasPermissionToMove) {

            transform.position = GetWorldPosition(transform);
            Debug.DrawRay(transform.position, Vector3.forward * 100);

            if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit)) {

                if (hit.collider.GetComponent<Square>()) {

                    square = hit.collider.GetComponent<Square>();
                }
            } 
            
            else {

                square = null;
            }
        }
    }
    internal void ResolveDragging() {

        while (isDragging) {

            if (square == null) {

                DisableDragging();
                SendBackToOrigin();
                break;
            }  
            
            else {

                bool thisMoveIsValid = validMoves.Contains(square);

                if (!thisMoveIsValid) {

                    DisableDragging();
                    SendBackToOrigin();
                    ResetRaycastSquare();
                    break;
                } 
                
                // Entweder gültiges Feld oder gegnerische Figut gehittet.
                else {

                    // gültiges Feld
                    if (square.CurrentSubscriber == null) {

                        this.piece.CurrentlySubscribedTo.RemoveSubscriber();
                        square.AddSubscriber(this.piece);
                        InCaseOfPawnCheckForHasMovedYet(this.piece);
                        DisableDragging();
                        ResetRaycastSquare();
                        break;
                    }

                    // gegnerische Figur
                    else if (square.CurrentSubscriber != null) {

                        this.piece.CurrentlySubscribedTo.RemoveSubscriber();
                        Board.Instance.Pieces.Remove(square.CurrentSubscriber);
                        Destroy(square.CurrentSubscriber.gameObject);
                        square.RemoveSubscriber();
                        square.AddSubscriber(this.piece);
                        InCaseOfPawnCheckForHasMovedYet(this.piece);
                        DisableDragging();
                        ResetRaycastSquare();
                        break;
                    }
                }
            }
        }

        DisableVisibilityOfPossibleMoves();
        UnapplyIgnoreRaycastLayerToAllPieces();
    }

    private void ApplyIgnoreRaycastLayerToAllPieces() {

        foreach (var element in Board.Instance.Pieces.Where(x => x != piece)) {

            element.gameObject.layer = 2;
        }
    }
    private void UnapplyIgnoreRaycastLayerToAllPieces() {

        foreach (var element in Board.Instance.Pieces.Where(x => x != piece)) {

            element.gameObject.layer = 10;
        }
    }
    private Vector3 GetWorldPosition(Transform t) {

        var desiredPosition = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.nearClipPlane));
        return desiredPosition;
    }
    private void DisableDragging() {

        isDragging = false;
    }
    private void SendBackToOrigin() {

        this.transform.position = origin;
    }
    private void ResetRaycastSquare () {

        square = null;
    }
    private void EnableVisibilityOfPossibleMoves() {

        if (validMoves.Count > 0) {

            foreach (var sq in validMoves) {

                sq.EnableValidMoveHightlight();
            }
        }
    }
    private void DisableVisibilityOfPossibleMoves() {

        if (validMoves.Count > 0) {

            foreach (var sq in validMoves) {

                sq.DisableValidMoveHighlight();
            }
        }
    }
    private void InCaseOfPawnCheckForHasMovedYet (Piece piece) {

        if (piece.GetType() == typeof(Pawn)) {

            var pawn = piece as Pawn;
            pawn.hasNotMovedYet = false;
        }
    }

}