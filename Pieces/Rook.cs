﻿


using UnityEngine;

namespace MauriceKoenig.ChessGame
{
    [RequireComponent(typeof(RookBehaviour))]
    public sealed class Rook : BasePiece
    {
        public override int Value { get; } = 5;
        public override string Name { get; } = "Rook";
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