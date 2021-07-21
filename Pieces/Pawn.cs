


using UnityEngine;

namespace MauriceKoenig.ChessGame
{
    [RequireComponent(typeof(PawnBehaviour))]
    public sealed class Pawn : BasePiece
    {
        public override int Value { get; } = 1;
        public override string Name { get; } = "Pawn";
        public override int InternalTurnCounter { get; set; }

        [PawnFlag] public bool HasNotMoved { get; set; } = true;
        [PawnFlag] public bool HasMovedTwoFields { get; set; } = false;
        [PawnFlag] public bool CanBeCapturedEnPassant { get; set; } = false;

        protected override void Awake() {
            base.Awake();
        }
        public override void BuildPiece(ColorProperty colorProperty, Square square) {
            base.BuildPiece(colorProperty, square);
            GetSprite();
            HasNotMoved = true;
        }
        protected override void GetSprite() {
            Renderer.sprite = ColorProperty ==
            ColorProperty.White ? Resources.Load<Sprite>("Sprites/white_pawn") :
            Resources.Load<Sprite>("Sprites/black_pawn");
        }
    }
}