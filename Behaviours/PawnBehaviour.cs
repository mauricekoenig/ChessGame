

using System.Collections.Generic;
using System.Linq;

public class PawnBehaviour : PieceBehaviour
{

    private PieceMover mover;
    public override List<Square> GetValidMoves() {

        validSquares.Clear();

        var temp = this.piece.Coordinates;
        var pawnRef = this.piece as Pawn;

        for (int i = 0; i < 2; i++) {

            if (this.piece.ColorProperty == ColorField.White) {


                temp.y++;
                var next = Board.Instance.Squares.Where(x => x.Coordinates == temp).ToList();
                if (next.Count() == 0) break;
                var newSquare = next.Single();

                if (newSquare.CurrentSubscriber != null) {

                    if (newSquare.CurrentSubscriber.ColorProperty == this.piece.ColorProperty) break;
                    if (newSquare.CurrentSubscriber.ColorProperty != this.piece.ColorProperty) break;
                }

                else if (newSquare.CurrentSubscriber == null) {

                    validSquares.Add(newSquare);
                    if (pawnRef.hasNotMovedYet) continue;
                    else break;
                }
            }

            else if (this.piece.ColorProperty == ColorField.Black) {

                temp.y--;
                var next = Board.Instance.Squares.Where(x => x.Coordinates == temp).ToList();
                if (next.Count() == 0) break;
                var newSquare = next.Single();

                if (newSquare.CurrentSubscriber != null) {

                    if (newSquare.CurrentSubscriber.ColorProperty == this.piece.ColorProperty) break;
                    if (newSquare.CurrentSubscriber.ColorProperty != this.piece.ColorProperty) break;
                }

                else if (newSquare.CurrentSubscriber == null) {

                    validSquares.Add(newSquare);
                    if (pawnRef.hasNotMovedYet) continue;
                    else break;

                }
            }
        }

        return validSquares;
    }

    protected override void Start() {

        base.Start();
    }

}