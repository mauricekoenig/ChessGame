


using UnityEngine;

[RequireComponent(typeof(QueenBehaviour))]
public sealed class Queen : Piece
{
    public override int Value { get; } = 9;
    public override string Name { get; } = "Queen";
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

            this.Sprite.sprite = Resources.Load<Sprite>("Sprites/white_queen");
        } 
        
        else {

            this.Sprite.sprite = Resources.Load<Sprite>("Sprites/black_queen");
        }
    }
}