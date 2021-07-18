


using UnityEngine;

public sealed class Square : MonoBehaviour
{
    private ColorField color;
    private bool initialized;
    private Color32 colorValue;
    private SpriteRenderer spriteRenderer;
    private GameObject validMoveHightlight;
    public Piece CurrentSubscriber;

    public string Notation { get; private set; }
    public Vector2 Coordinates { get; private set; }

    private void Awake() {

        this.initialized = false;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.validMoveHightlight = transform.GetChild(0).gameObject;
        validMoveHightlight.SetActive(false);
    }
    internal void InitializeSquare (Vector2 coordinates, Color32 squareColor, ColorField colorField) {

        if (initialized) return;
        this.Coordinates = coordinates;
        this.colorValue = squareColor;
        this.spriteRenderer.color = this.colorValue;
        this.color = colorField;
        this.Notation = ChessUtil.GetNotation(Coordinates);
        this.gameObject.name = Notation;
        this.initialized = true;
    }
    internal void EnableValidMoveHightlight () {

        this.validMoveHightlight.SetActive(true);
    }
    internal void DisableValidMoveHighlight() {

        this.validMoveHightlight.SetActive(false);
    }
    /// <summary>
    /// Überschreibt alle notwendigen Daten und aktualisiert die Position.
    /// </summary>
    /// <param name="piece"></param>
    internal void AddSubscriber (Piece piece) {

        this.CurrentSubscriber = piece;
        piece.CurrentlySubscribedTo = this;
        piece.Coordinates = this.Coordinates;
        piece.transform.position = this.transform.position + new Vector3(0, 0, Constants.PieceZOffset);
        piece.gameObject.name = $"{piece.ColorProperty.ToString()} {piece.Name} {this.Notation}";
        ChessUtil.CalculateBoardValues();
    }
    internal void RemoveSubscriber () {

        CurrentSubscriber = null;
    }

}