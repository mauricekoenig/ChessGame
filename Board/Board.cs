

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace MauriceKoenig.ChessGame
{
    public sealed class Board : MonoBehaviour {

        public static Board Instance { get; set; }
        public List<Square> Squares;
        public List<BasePiece> Pieces;

        public int BlackValue { get; set; }
        public int WhiteValue { get; set; }

        [KingFlag] public King WhiteKing { get; private set; }
        [KingFlag] public King BlackKing { get; private set; }

        [Space(30)]
        [Header("Prefabs")]
        [SerializeField] private GameObject _pieceFab;
        [SerializeField] private GameObject _squareFab;
        [SerializeField] private Transform _squareParent;
        [SerializeField] private Transform _pieceParent;

        private void Awake() {

            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            this.Squares = new List<Square>();
        }
        private void Start() {

            CreateBoard();
        }
        private void Update() {

            TemporaryCheat();
        }

        private void CreateBoard() {

            var white = false;

            for (int x = 1; x <= 8; x++) {

                for (int y = 1; y <= 8; y++) {

                    var instance = Instantiate(_squareFab, Vector3.zero, Quaternion.identity, _squareParent);
                    var square = instance.GetComponent<Square>();
                    var coordinates = new Vector2(x, y);

                    Color32 colorCode;
                    ColorProperty colorField;

                    Vector3 position = new Vector3((1 * x), (1 * y), 0);
                    instance.transform.position = position;

                    if (white) {

                        colorCode = Constants.WhiteSquareColor;
                        colorField = ColorProperty.White;
                    } else {

                        colorCode = Constants.BlackSquareColor;
                        colorField = ColorProperty.Black;
                    }

                    square.BuildSquare(coordinates, colorCode, colorField);
                    Squares.Add(square);

                    if (y == 8) break;
                    if (white) white = false;
                    else white = true;

                }
            }

            if (Squares.Count == 64)
                CreatePieces();

            if (Pieces.Count == 32)
                ChessUtility.CalculateBoardValues();

        }
        public void CreatePiece(PieceType pieceType, ColorProperty colorInfo, string notation) {

            Square square = Squares.Where(a => a.Notation == notation).Single();
            if (square == null) return;

            var piece = Instantiate(_pieceFab, square.transform.position, Quaternion.identity, _pieceParent);

            switch (pieceType) {

                case PieceType.Pawn:
                    piece.AddComponent<Pawn>();
                    var script = piece.GetComponent<BasePiece>();
                    script.BuildPiece(colorInfo, square);
                    break;

                case PieceType.King:
                    piece.AddComponent<King>();
                    var king = piece.GetComponent<BasePiece>();
                    king.BuildPiece(colorInfo, square);
                    break;

                case PieceType.Queen:
                    piece.AddComponent<Queen>();
                    var queen = piece.GetComponent<BasePiece>();
                    queen.BuildPiece(colorInfo, square);
                    break;

                case PieceType.Knight:
                    piece.AddComponent<Knight>();
                    var knight = piece.GetComponent<BasePiece>();
                    knight.BuildPiece(colorInfo, square);
                    break;

                case PieceType.Bishop:
                    piece.AddComponent<Bishop>();
                    var bishop = piece.GetComponent<BasePiece>();
                    bishop.BuildPiece(colorInfo, square);
                    break;

                case PieceType.Rook:
                    piece.AddComponent<Rook>();
                    var rook = piece.GetComponent<BasePiece>();
                    rook.BuildPiece(colorInfo, square);
                    break;
            }
            Pieces.Add(piece.GetComponent<BasePiece>());
        }
        private void CreatePieces() {

            // white pieces
            CreatePiece(PieceType.Pawn, ColorProperty.White, "a2");
            CreatePiece(PieceType.Pawn, ColorProperty.White, "b2");
            CreatePiece(PieceType.Pawn, ColorProperty.White, "c2");
            CreatePiece(PieceType.Pawn, ColorProperty.White, "d2");
            CreatePiece(PieceType.Pawn, ColorProperty.White, "e2");
            CreatePiece(PieceType.Pawn, ColorProperty.White, "f2");
            CreatePiece(PieceType.Pawn, ColorProperty.White, "g2");
            CreatePiece(PieceType.Pawn, ColorProperty.White, "h2");

            CreatePiece(PieceType.Knight, ColorProperty.White, "b1");
            CreatePiece(PieceType.Knight, ColorProperty.White, "g1");

            CreatePiece(PieceType.Bishop, ColorProperty.White, "c1");
            CreatePiece(PieceType.Bishop, ColorProperty.White, "f1");

            CreatePiece(PieceType.Rook, ColorProperty.White, "a1");
            CreatePiece(PieceType.Rook, ColorProperty.White, "h1");

            CreatePiece(PieceType.Queen, ColorProperty.White, "d1");
            CreatePiece(PieceType.King, ColorProperty.White, "e1");

            // black pieces
            CreatePiece(PieceType.Pawn, ColorProperty.Black, "a7");
            CreatePiece(PieceType.Pawn, ColorProperty.Black, "b7");
            CreatePiece(PieceType.Pawn, ColorProperty.Black, "c7");
            CreatePiece(PieceType.Pawn, ColorProperty.Black, "d7");
            CreatePiece(PieceType.Pawn, ColorProperty.Black, "e7");
            CreatePiece(PieceType.Pawn, ColorProperty.Black, "f4");
            CreatePiece(PieceType.Pawn, ColorProperty.Black, "g7");
            CreatePiece(PieceType.Pawn, ColorProperty.Black, "h7");

            CreatePiece(PieceType.Knight, ColorProperty.Black, "b8");
            CreatePiece(PieceType.Knight, ColorProperty.Black, "g8");

            CreatePiece(PieceType.Bishop, ColorProperty.Black, "c8");
            CreatePiece(PieceType.Bishop, ColorProperty.Black, "f8");

            CreatePiece(PieceType.Rook, ColorProperty.Black, "a8");
            CreatePiece(PieceType.Rook, ColorProperty.Black, "h8");

            CreatePiece(PieceType.Queen, ColorProperty.Black, "d8");
            CreatePiece(PieceType.King, ColorProperty.Black, "e8");
        }

        [DebuggingTool("Remove pawns for space")] 
        private void TemporaryCheat() {

            if (Input.GetKeyDown(KeyCode.U)) {

                Pieces.Remove(Squares.Where(a => a.Notation == "d2").Single().CurrentSubscriber);
                Pieces.Remove(Squares.Where(a => a.Notation == "b2").Single().CurrentSubscriber);
                Destroy(Squares.Where(a => a.Notation == "d2").Single().CurrentSubscriber.gameObject);
                Destroy(Squares.Where(a => a.Notation == "b2").Single().CurrentSubscriber.gameObject);
                Squares.Where(a => a.Notation == "d2").Single().RemoveSubscriber();
                Squares.Where(a => a.Notation == "b2").Single().RemoveSubscriber();
                ChessUtility.CalculateBoardValues();
            }

        }

        [KingFlag]
        public void RegisterKing(ColorProperty colorProperty, King king) {

            if (colorProperty == ColorProperty.Black) BlackKing = king;
            else if (colorProperty == ColorProperty.White) WhiteKing = king;
            else return;
        }

        [KingFlag]
        public bool PieceIsPinned (BasePiece basePiece) {

            if (basePiece.Name == "King") return false;
            var currentSquare = basePiece.UnderlyingSquare;
            currentSquare.RemoveSubscriber();

            if (KingIsChecked(basePiece.ColorProperty)) {
                basePiece.UnderlyingSquare.SetSubscriber(basePiece);
                return true;
            } 

            else {
                basePiece.UnderlyingSquare.SetSubscriber(basePiece);
                return false;
            }
        }

        [KingFlag]
        public bool KingIsChecked (ColorProperty colorProperty) {

            if (colorProperty == ColorProperty.White) {
                var blackSequence = Pieces.Where(b => b.ColorProperty == ColorProperty.Black).ToList();
                for (int i = 0; i < blackSequence.Count; i++) {
                    var moves = blackSequence[i].GetBehaviour().GetValidMoves();
                    if (moves.Contains(WhiteKing.UnderlyingSquare))
                        return true;
                }
            } 
            
            else if (colorProperty == ColorProperty.Black) {
                var whiteSequence = Pieces.Where(w => w.ColorProperty == ColorProperty.White).ToList();
                for (int i = 0; i < whiteSequence.Count; i++) {
                    var moves = whiteSequence[i].GetBehaviour().GetValidMoves();
                    if (moves.Contains(BlackKing.UnderlyingSquare))
                        return true;
                }
            }

            return false;
        }
    }
}