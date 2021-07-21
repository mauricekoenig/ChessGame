


using UnityEngine;

namespace MauriceKoenig.ChessGame
{
    [RequireComponent(typeof(KnightBehaviour))]
    public sealed class Knight : BasePiece, IPinnable
    {
        public override int Value { get; } = 3;
        public override string Name { get; } = "Knight";
        public override int InternalTurnCounter { get; set; }
        public bool IsPinned { get; set; }

        protected override void Awake() {

            base.Awake();
        }
        public override void BuildPiece(ColorProperty colorProperty, Square square) {

            base.BuildPiece(colorProperty, square);
            GetSprite();
        }
        protected override void GetSprite() {
            Renderer.sprite = ColorProperty ==
            ColorProperty.White ? Resources.Load<Sprite>("Sprites/white_knight") :
            Resources.Load<Sprite>("Sprites/black_knight");
        }
    }
}