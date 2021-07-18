

using UnityEngine;

[RequireComponent(typeof(PieceMover))]
public sealed class PieceController : MonoBehaviour
{
    internal Piece piece;
    private PieceMover mover;

    private void Start () {

        piece = GetComponent<Piece>();
        mover = GetComponent<PieceMover>();
    }

    private void OnMouseDown() {

        mover.PrepareDragging();
    }
    private void OnMouseDrag() {

        mover.DragAndRaycast();
    }
    private void OnMouseUp() {

        mover.ResolveDragging();
    }

}