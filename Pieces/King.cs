


using UnityEngine;

namespace MauriceKoenig.ChessGame
{
    [RequireComponent(typeof(KingBehaviour))]
    public sealed class King : BasePiece
    {
        public override int Value { get; } = 0;
        public override string Name { get; } = "King";
        public override int InternalTurnCounter { get; set; }

        protected override void Awake() {

            base.Awake();
        }
        public override void BuildPiece(ColorProperty colorProperty, Square square) {

            base.BuildPiece(colorProperty, square);
            GetSprite();
        }
        protected override void GetSprite() {
            Renderer.sprite = ColorProperty ==
            ColorProperty.White ? Resources.Load<Sprite>("Sprites/white_king") :
            Resources.Load<Sprite>("Sprites/black_king");
        }
    }
}