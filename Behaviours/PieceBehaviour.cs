


using System.Collections.Generic;
using UnityEngine;

public abstract class PieceBehaviour : MonoBehaviour
{
    protected Piece piece;
    protected List<Square> validSquares = new List<Square>();

    protected virtual void Start() {

        piece = GetComponent<Piece>();
    }

    public abstract List<Square> GetValidMoves();
}