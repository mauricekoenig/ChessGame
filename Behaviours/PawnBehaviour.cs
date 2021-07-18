

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PawnBehaviour : PieceBehaviour
{

    private PieceMover mover;
    public override List<Square> GetValidMoves() {

        validSquares.Clear();

        var temp = this.piece.Coordinates;
        var pawnRef = this.piece as Pawn;

        // ein oder zwei Felder zu Beginn - je nachdem.
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

        temp = this.piece.Coordinates;
        // Checke für Gegner: OBEN LINKS.
        for (int i = 0; i < 1; i++) {

            if (this.piece.ColorProperty == ColorField.White) {

                temp.y++; temp.x--;
                var next = Board.Instance.Squares.Where(x => x.Coordinates == temp).ToList();
                if (next.Count() == 0) break;
                var newSquare = next.Single();

                if (newSquare.CurrentSubscriber != null) {

                    if (newSquare.CurrentSubscriber.ColorProperty == this.piece.ColorProperty) break;
                    if (newSquare.CurrentSubscriber.ColorProperty != this.piece.ColorProperty) {

                        validSquares.Add(newSquare);
                        break;
                    }
                }
            }

            if (this.piece.ColorProperty == ColorField.Black) {

                temp.y--; temp.x++;
                var next = Board.Instance.Squares.Where(x => x.Coordinates == temp).ToList();
                if (next.Count() == 0) break;
                var newSquare = next.Single();

                if (newSquare.CurrentSubscriber != null) {

                    if (newSquare.CurrentSubscriber.ColorProperty == this.piece.ColorProperty) break;
                    if (newSquare.CurrentSubscriber.ColorProperty != this.piece.ColorProperty) {

                        validSquares.Add(newSquare);
                        break;
                    }
                }
            }
        }

        temp = this.piece.Coordinates;
        // Gegner ermitteln: OBEN RECHTS.
        for (int i = 0; i < 1; i++) {

            if (this.piece.ColorProperty == ColorField.White) {

                temp.y++; temp.x++;
                var next = Board.Instance.Squares.Where(x => x.Coordinates == temp).ToList();
                if (next.Count() == 0) break;
                var newSquare = next.Single();

                if (newSquare.CurrentSubscriber != null) {

                    if (newSquare.CurrentSubscriber.ColorProperty == this.piece.ColorProperty) break;
                    if (newSquare.CurrentSubscriber.ColorProperty != this.piece.ColorProperty) {

                        validSquares.Add(newSquare);
                        break;
                    }
                }
            }

            if (this.piece.ColorProperty == ColorField.Black) {

                temp.y--; temp.x--;
                var next = Board.Instance.Squares.Where(x => x.Coordinates == temp).ToList();
                if (next.Count() == 0) break;
                var newSquare = next.Single();

                if (newSquare.CurrentSubscriber != null) {

                    if (newSquare.CurrentSubscriber.ColorProperty == this.piece.ColorProperty) break;
                    if (newSquare.CurrentSubscriber.ColorProperty != this.piece.ColorProperty) {

                        validSquares.Add(newSquare);
                        break;
                    }
                }
            }
        }

        return validSquares;
    }

    protected override void Start() {

        base.Start();
    }

}