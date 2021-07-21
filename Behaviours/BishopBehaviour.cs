

using System.Collections.Generic;
using System.Linq;

namespace MauriceKoenig.ChessGame
{
    public sealed class BishopBehaviour : PieceBehaviour
    {
        protected override void Start() {

            base.Start();
        }
        public override List<Square> GetValidMoves() {

            validSquares.Clear();

            // top-right
            var temp = this.piece.Coordinates;
            while (temp.x < 8 && temp.y < 8) {

                temp.x++; temp.y++;
                var next = Board.Instance.Squares.Where(x => x.Coordinates == temp);
                if (next.Count() == 0) break;
                var newSquare = next.Single();

                // Subscriber exists.
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
            while (temp.x < 8 && temp.y > 1) {

                temp.x++; temp.y--;
                var next = Board.Instance.Squares.Where(x => x.Coordinates == temp);
                if (next.Count() == 0) break;
                var newSquare = next.Single();

                // Subscriber exists.
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
            while (temp.x > 1 && temp.y < 8) {

                temp.y++; temp.x--;
                var next = Board.Instance.Squares.Where(x => x.Coordinates == temp);
                if (next.Count() == 0) break;
                var newSquare = next.Single();

                // Subscriber exists.
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
            while (temp.y > 1 && temp.x > 1) {

                temp.y--; temp.x--;
                var next = Board.Instance.Squares.Where(x => x.Coordinates == temp);
                if (next.Count() == 0) break;
                var newSquare = next.Single();

                // Subscriber exists.
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
}