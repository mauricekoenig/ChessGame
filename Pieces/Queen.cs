


using UnityEngine;

namespace MauriceKoenig.ChessGame
{
    [RequireComponent(typeof(QueenBehaviour))]
    public sealed class Queen : BasePiece, IPinnable
    {
        public override int Value { get; } = 9;
        public override string Name { get; } = "Queen";
        public override int InternalTurnCounter { get; set; }
        public bool IsPinned { get; set; }

        protected override void Awake() {

            base.Awake();
        }
        public override void BuildPiece(ColorProperty colorField, Square square) {
            base.BuildPiece(colorField, square);
            GetSprite();
        }
        protected override void GetSprite() {
            Renderer.sprite = ColorProperty ==
            ColorProperty.White ? Resources.Load<Sprite>("Sprites/white_queen") :
            Resources.Load<Sprite>("Sprites/black_queen");
        }

    }
}