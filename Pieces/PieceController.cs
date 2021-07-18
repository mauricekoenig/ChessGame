


using System.Collections.Generic;
using System.Linq;
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

        Mover.PrepareFireRay();
    }
    private void OnMouseDrag() {

        Mover.FireRay();
    }
    private void OnMouseUp() {

        Mover.ResolveFireRay();
    }

}