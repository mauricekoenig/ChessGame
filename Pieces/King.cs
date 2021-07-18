


using UnityEngine;

[RequireComponent(typeof(KingBehaviour))]
public sealed class King : Piece
{
    public override int Value { get; } = 0;
    public override string Name { get; } = "King";

    protected override void Awake() {

        base.Awake();
    }
    public  override void InitializePiece(ColorField colorField, Square square) {

        base.InitializePiece(colorField, square);
        LoadSprite();
    }
    protected override void LoadSprite() {

        if (this.ColorProperty == ColorField.White) {

            this.Sprite.sprite = Resources.Load<Sprite>("Sprites/white_king");
        } else {

            this.Sprite.sprite = Resources.Load<Sprite>("Sprites/black_king");
        }
    }
}