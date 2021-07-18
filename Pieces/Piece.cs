


using UnityEngine;

[RequireComponent(typeof(PieceController))]
public abstract class Piece : MonoBehaviour
{
    public abstract string Name { get; }
    public abstract int Value { get; }
    public string Notation { get; private set; }
    public Square CurrentlySubscribedTo { get; set; }

    protected PieceBehaviour pieceBehaviour;
    public SpriteRenderer Sprite { get; set; }
    public ColorField ColorProperty { get; private set; }
    public Vector2 Coordinates;

    protected virtual void Awake() {

        this.pieceBehaviour = GetComponent<PieceBehaviour>();
        this.Sprite = GetComponent<SpriteRenderer>();
    }
    protected virtual void LoadSprite () {
        // no implementation in base class
    }
    public virtual void InitializePiece (ColorField colorField, Square square) {

        this.ColorProperty = colorField;
        this.Coordinates = square.Coordinates;
        this.Notation = ChessUtil.GetNotation(Coordinates);
        this.gameObject.name = $"{this.ColorProperty.ToString()} {this.Name} {this.Notation}";
        square.AddSubscriber(this);
    }
    public PieceBehaviour GetBehaviour() {

        return pieceBehaviour;
    }

}