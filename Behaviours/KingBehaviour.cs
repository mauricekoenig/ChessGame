

using System.Collections.Generic;
using System.Linq;

public class KingBehaviour : PieceBehaviour
{
    protected override void Start() {

        base.Start();
    }

    public override List<Square> GetValidMoves() {

        validSquares.Clear();

        // top-right
        var temp = this.piece.Coordinates;

        for (int i = 0; i < 1; i++) {

            temp.x++; temp.y++;
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

            validSquares.Add(newSquare);
        }
        temp = this.piece.Coordinates;

        for (int i = 0; i < 1; i++) {

            temp.x++; temp.y++;
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

            validSquares.Add(newSquare);
        }
        // bottom-right

        temp = this.piece.Coordinates;
        for (int i = 0; i < 1; i++) {
            temp.x++; temp.y--;
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

            validSquares.Add(newSquare);
        }
        // top-left 

        temp = this.piece.Coordinates;
        for (int i = 0; i < 1; i++) {
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

            validSquares.Add(newSquare);
        }

        // bottom-left
        temp = this.piece.Coordinates;
        for (int i = 0; i < 1; i++) {
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

            validSquares.Add(newSquare);
        }

        // right
        temp = this.piece.Coordinates;
        for (int i = 0; i < 1; i++) {
            temp.x++;
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

            validSquares.Add(newSquare);
        }

        // left
        temp = this.piece.Coordinates;
        for (int i = 0; i < 1; i++) {

            temp.x--;
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

            validSquares.Add(newSquare);
        }

        // up
        temp = this.piece.Coordinates;
        for (int i = 0; i < 1; i++) {
            temp.y++;
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

            validSquares.Add(newSquare);
        }

        // down
        temp = this.piece.Coordinates;
        for (int i = 0; i < 1; i++) {

            temp.y--;
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

            validSquares.Add(newSquare);
        }

        return this.validSquares;
    }
}