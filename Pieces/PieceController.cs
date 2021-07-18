

using UnityEngine;

[RequireComponent(typeof(PieceMover))]
public sealed class PieceController : MonoBehaviour
{
    internal Piece piece;
    private PieceBehaviour pieceBehaviour;
    private PieceMover Mover;

    private void Start () {

        piece = GetComponent<Piece>();
        pieceBehaviour = GetComponent<PieceBehaviour>();
        Mover = GetComponent<PieceMover>();
    }
    private void OnMouseDown() {

        Mover.PrepareDragging();
    }
    private void OnMouseDrag() {

        Mover.DragAndRaycast();
    }
    private void OnMouseUp() {

        Mover.ResolveDragging();
    }

}