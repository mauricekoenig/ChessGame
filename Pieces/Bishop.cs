


using UnityEngine;

namespace MauriceKoenig.ChessGame
{
    [RequireComponent(typeof(BishopBehaviour))]
    public sealed class Bishop : BasePiece
    {
        public override int Value { get; } = 3;
        public override string Name { get; } = "Bishop";
        public override int InternalTurnCounter { get; set; }

        protected override void Awake() {

            base.Awake();
        }
        public override void BuildPiece(ColorProperty colorField, Square square) {
            base.BuildPiece(colorField, square);
            GetSprite();
        }
        protected override void GetSprite() {
            Renderer.sprite = ColorProperty == 
            ColorProperty.White ? Resources.Load<Sprite>("Sprites/white_bishop") : 
            Resources.Load<Sprite>("Sprites/black_bishop");
        }
    }
}