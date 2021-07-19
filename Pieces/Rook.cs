


using UnityEngine;

[RequireComponent(typeof(RookBehaviour))]
public sealed class Rook : Piece
{
    public override int Value { get; } = 5;
    public override string Name { get; } = "Rook";
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

            this.Sprite.sprite = Resources.Load<Sprite>("Sprites/white_rook");
        } 
        
        else {

            this.Sprite.sprite = Resources.Load<Sprite>("Sprites/black_rook");
        }
    }
}