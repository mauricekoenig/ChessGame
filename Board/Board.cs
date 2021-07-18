

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public sealed class Board : MonoBehaviour
{
    [Space(30)] [Header("Lists")]
    public static Board Instance;
    public List<Square> Squares;
    public List<Piece> Pieces;

    [Space(30)] [Header("Values On Board")]
    public int BlackValue;
    public int WhiteValue;

    [Space(30)] [Header("Prefabs")]
    [SerializeField] private GameObject pieceFab;
    [SerializeField] private GameObject squareFab;
    [SerializeField] private Transform squareParent;
    [SerializeField] private Transform pieceParent;

    private void Awake() {

        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        this.Squares = new List<Square>();
    }
    private void Start() {

        CreateGameSetup();
    }

    private void CreateGameSetup () {

        var white = false;

        for (int x = 1; x <= 8; x++) {

            for (int y = 1; y <= 8; y++) {

                var instance = Instantiate(squareFab, Vector3.zero, Quaternion.identity, squareParent);
                var square = instance.GetComponent<Square>();
                var coordinates = new Vector2(x, y);

                Color32 colorCode;
                ColorField colorField;

                Vector3 position = new Vector3((1 * x), (1 * y), 0);
                instance.transform.position = position;

                if (white) {

                    colorCode = Constants.WhiteSquareColor;
                    colorField = ColorField.White;
                } 
                
                else {

                    colorCode = Constants.BlackSquareColor;
                    colorField = ColorField.Black;
                }

                square.InitializeSquare(coordinates, colorCode, colorField);
                Squares.Add(square);

                if (y == 8) break;
                if (white) white = false;
                else white = true;

            }
        }

        if (Squares.Count == 64) 
            CreateAllPieces();

        if (Pieces.Count == 32)
            ChessUtil.CalculateBoardValues();

    }
    public void CreatePiece (PieceType pieceType, ColorField colorInfo, string notation) {

        Square square = Squares.Where(a => a.Notation == notation).Single();
        if (square == null) return;

        var piece = Instantiate(pieceFab, square.transform.position, Quaternion.identity, pieceParent);

        switch (pieceType) {

            case PieceType.Pawn:
                piece.AddComponent<Pawn>();
                var script = piece.GetComponent<Piece>();
                script.InitializePiece(colorInfo, square);
                break;

            case PieceType.King:
                piece.AddComponent<King>();
                var king = piece.GetComponent<Piece>();
                king.InitializePiece(colorInfo, square);
                break;

            case PieceType.Queen:
                piece.AddComponent<Queen>();
                var queen = piece.GetComponent<Piece>();
                queen.InitializePiece(colorInfo, square);
                break;

            case PieceType.Knight:
                piece.AddComponent<Knight>();
                var knight = piece.GetComponent<Piece>();
                knight.InitializePiece(colorInfo, square);
                break;

            case PieceType.Bishop:
                piece.AddComponent<Bishop>();
                var bishop = piece.GetComponent<Piece>();
                bishop.InitializePiece(colorInfo, square);
                break;

            case PieceType.Rook:
                piece.AddComponent<Rook>();
                var rook = piece.GetComponent<Piece>();
                rook.InitializePiece(colorInfo, square);
                break;
        }
        Pieces.Add( piece.GetComponent<Piece>() ) ;
    }
    private void CreateAllPieces () {

        // white pieces
        CreatePiece(PieceType.Pawn, ColorField.White, "a2");
        CreatePiece(PieceType.Pawn, ColorField.White, "b2");
        CreatePiece(PieceType.Pawn, ColorField.White, "c2");
        CreatePiece(PieceType.Pawn, ColorField.White, "d2");
        CreatePiece(PieceType.Pawn, ColorField.White, "e2");
        CreatePiece(PieceType.Pawn, ColorField.White, "f2");
        CreatePiece(PieceType.Pawn, ColorField.White, "g2");
        CreatePiece(PieceType.Pawn, ColorField.White, "h2");

        CreatePiece(PieceType.Knight, ColorField.White, "b1");
        CreatePiece(PieceType.Knight, ColorField.White, "g1");

        CreatePiece(PieceType.Bishop, ColorField.White, "c1");
        CreatePiece(PieceType.Bishop, ColorField.White, "f1");

        CreatePiece(PieceType.Rook, ColorField.White, "a1");
        CreatePiece(PieceType.Rook, ColorField.White, "h1");

        CreatePiece(PieceType.Queen, ColorField.White, "d1");
        CreatePiece(PieceType.King, ColorField.White, "e1");

        // black pieces
        CreatePiece(PieceType.Pawn, ColorField.Black, "a7");
        CreatePiece(PieceType.Pawn, ColorField.Black, "b7");
        CreatePiece(PieceType.Pawn, ColorField.Black, "c7");
        CreatePiece(PieceType.Pawn, ColorField.Black, "d7");
        CreatePiece(PieceType.Pawn, ColorField.Black, "e7");
        CreatePiece(PieceType.Pawn, ColorField.Black, "f4");
        CreatePiece(PieceType.Pawn, ColorField.Black, "g7");
        CreatePiece(PieceType.Pawn, ColorField.Black, "h7");

        CreatePiece(PieceType.Knight, ColorField.Black, "b8");
        CreatePiece(PieceType.Knight, ColorField.Black, "g8");

        CreatePiece(PieceType.Bishop, ColorField.Black, "c8");
        CreatePiece(PieceType.Bishop, ColorField.Black, "f8");

        CreatePiece(PieceType.Rook, ColorField.Black, "a8");
        CreatePiece(PieceType.Rook, ColorField.Black, "h8");

        CreatePiece(PieceType.Queen, ColorField.Black, "d8");
        CreatePiece(PieceType.King, ColorField.Black, "e8");
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.U)) {

            Destroy(Squares.Where(a => a.Notation == "d2").Single().CurrentSubscriber.gameObject);
            Destroy(Squares.Where(a => a.Notation == "b2").Single().CurrentSubscriber.gameObject);
            Squares.Where(a => a.Notation == "d2").Single().RemoveSubscriber();
            Squares.Where(a => a.Notation == "b2").Single().RemoveSubscriber();
        }
    }
}