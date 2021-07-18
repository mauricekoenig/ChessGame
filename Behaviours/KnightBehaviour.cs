

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KnightBehaviour : PieceBehaviour
{

    public override List<Square> GetValidMoves() {

        validSquares.Clear();
        var temp = this.piece.Coordinates;

        temp.x--;
        temp.y -= 2;
        var move1 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move1.Count() == 1) validSquares.Add(move1.Single());
        temp = this.piece.Coordinates;

        temp.x--;
        temp.y += 2;
        var move2 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move2.Count() == 1) validSquares.Add(move2.Single());
        temp = this.piece.Coordinates;

        temp.x -= 2;
        temp.y--;
        var move3 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move3.Count() == 1) validSquares.Add(move3.Single());
        temp = this.piece.Coordinates;

        temp.x -= 2;
        temp.y++;
        var move4 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move4.Count() == 1) validSquares.Add(move4.Single());
        temp = this.piece.Coordinates;

        temp.x++;
        temp.y += 2;
        var move5 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move5.Count() == 1) validSquares.Add(move5.Single());
        temp = this.piece.Coordinates;

        temp.x++;
        temp.y -= 2;
        var move6 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move6.Count() == 1) validSquares.Add(move6.Single());
        temp = this.piece.Coordinates;

        temp.x += 2;
        temp.y--;
        var move7 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move7.Count() == 1) validSquares.Add(move7.Single());
        temp = this.piece.Coordinates;

        temp.x += 2;
        temp.y++;
        var move8 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move8.Count() == 1) validSquares.Add(move8.Single());

        return validSquares;
    }
    protected override void Start() {

        base.Start();
    }
}