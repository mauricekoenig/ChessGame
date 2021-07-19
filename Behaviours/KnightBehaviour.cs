

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
        if (move1.Count() == 1) {
            Square move1Square = move1.Single();
            if (move1Square.CurrentSubscriber != null) {
                if (move1Square.CurrentSubscriber.ColorProperty != this.piece.ColorProperty)
                    validSquares.Add(move1Square);
            }        else validSquares.Add(move1Square);
        }              temp = this.piece.Coordinates;

        temp.x--;
        temp.y += 2;
        var move2 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move2.Count() == 1) {
            Square move2Square = move2.Single();
            if (move2Square.CurrentSubscriber != null) {
                if (move2Square.CurrentSubscriber.ColorProperty != this.piece.ColorProperty)
                    validSquares.Add(move2Square);
            }           else validSquares.Add(move2Square);
        }                 temp = this.piece.Coordinates;



        temp.x -= 2;
        temp.y--;
        var move3 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move1.Count() == 1) {
            Square move3Square = move3.Single();
            if (move3Square.CurrentSubscriber != null) {
                if (move3Square.CurrentSubscriber.ColorProperty != this.piece.ColorProperty)
                    validSquares.Add(move3Square);
            }           else validSquares.Add(move3Square);
        }                 temp = this.piece.Coordinates;

        temp.x -= 2;
        temp.y++;
        var move4 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move4.Count() == 1) {
            Square move4Square = move4.Single();
            if (move4Square.CurrentSubscriber != null) {
                if (move4Square.CurrentSubscriber.ColorProperty != this.piece.ColorProperty)
                    validSquares.Add(move4Square);
            }         else validSquares.Add(move4Square);
        }               temp = this.piece.Coordinates;

        temp.x++;
        temp.y += 2;
        var move5 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move5.Count() == 1) {
            Square move5Square = move5.Single();
            if (move5Square.CurrentSubscriber != null) {
                if (move5Square.CurrentSubscriber.ColorProperty != this.piece.ColorProperty)
                    validSquares.Add(move5Square);
            }           else validSquares.Add(move5Square);
        }                 temp = this.piece.Coordinates;

        temp.x++;
        temp.y -= 2;
        var move6 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move6.Count() == 1) {
            Square move6Square = move6.Single();
            if (move6Square.CurrentSubscriber != null) {
                if (move6Square.CurrentSubscriber.ColorProperty != this.piece.ColorProperty)
                    validSquares.Add(move6Square);
            }           else validSquares.Add(move6Square);
                            temp = this.piece.Coordinates;
        }

        temp.x += 2;
        temp.y--;
        var move7 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move7.Count() == 1) {
            Square move7Square = move7.Single();
            if (move7Square.CurrentSubscriber != null) {
                if (move7Square.CurrentSubscriber.ColorProperty != this.piece.ColorProperty)
                    validSquares.Add(move7Square);
            }           else validSquares.Add(move7Square);
        }                 temp = this.piece.Coordinates;

        temp.x += 2;
        temp.y++;
        var move8 = Board.Instance.Squares.Where(x => x.Coordinates == temp);
        if (move8.Count() == 1) {
            Square move8Square = move8.Single();
            if (move8Square.CurrentSubscriber != null) {
                if (move8Square.CurrentSubscriber.ColorProperty != this.piece.ColorProperty)
                    validSquares.Add(move8Square);
            }         else validSquares.Add(move8Square);
        }               temp = this.piece.Coordinates;

        return validSquares;
    }
    protected override void Start() {

        base.Start();
    }
}