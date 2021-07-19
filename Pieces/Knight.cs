


using UnityEngine;

[RequireComponent(typeof(KnightBehaviour))]
public sealed class Knight : Piece
{
    public override int Value { get; } = 3;
    public override string Name { get; } = "Knight";
    public override int InternalCounter { get; set; }

    protected override void Awake() {

        base.Awake();
    }
    public override void InitializePiece(ColorField colorField, Square square) {

        base.InitializePiece(colorField, square);
        LoadSprite();
    }
    protected override void LoadSprite() {

        if (this.ColorProperty == ColorField.White) {

            this.Sprite.sprite = Resources.Load<Sprite>("Sprites/white_knight");
        }
        
        else {

            this.Sprite.sprite = Resources.Load<Sprite>("Sprites/black_knight");
        }
    }
}