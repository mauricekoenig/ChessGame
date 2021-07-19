


using UnityEngine;

[RequireComponent(typeof(PawnBehaviour))]
public sealed class Pawn : Piece
{
    public override int Value { get; } = 1;
    public override string Name { get; } = "Pawn";

    public bool hasNotMovedYet = false;
    public bool hasMoved2Fields = false;

    protected override void Awake() {

        base.Awake();
    }
    public override void InitializePiece(ColorField colorField, Square square) {

        base.InitializePiece(colorField, square);
        LoadSprite();
        hasNotMovedYet = true;
    }
    protected override void LoadSprite() {

        if (this.ColorProperty == ColorField.White) {

            this.Sprite.sprite = Resources.Load<Sprite>("Sprites/white_pawn");
        } 
        
        else {

            this.Sprite.sprite = Resources.Load<Sprite>("Sprites/black_pawn");
        }
    }
}