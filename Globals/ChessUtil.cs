


using System.Linq;
using UnityEngine;


public static class ChessUtil
{

    public static string GetNotation (Vector2 coordinates) {

        switch (coordinates.x) {

            case 1:
                return $"a{coordinates.y}";
            case 2:
                return $"b{coordinates.y}";
            case 3:
                return $"c{coordinates.y}";
            case 4:
                return $"d{coordinates.y}";
            case 5:
                return $"e{coordinates.y}";
            case 6:
                return $"f{coordinates.y}";
            case 7:
                return $"g{coordinates.y}";
            case 8:
                return $"h{coordinates.y}";

            default:
                return null;
        }
    }
    public static Piece GetPiece (string notation) {

        return Board.Instance.Pieces.Where(x => x.Notation == notation).Single();
    }
    public static void CalculateBoardValues () {


        Board.Instance.WhiteValue = 0;
        Board.Instance.BlackValue = 0;

        var whitePieces = Board.Instance.Pieces.Where(w => w.ColorProperty == ColorField.White);
        var blackPieces = Board.Instance.Pieces.Where(b => b.ColorProperty == ColorField.Black);

        foreach (var white in whitePieces) {

            Board.Instance.WhiteValue += white.Value;
        }

        foreach (var black in blackPieces) {

            Board.Instance.BlackValue += black.Value;
        }
    }
}