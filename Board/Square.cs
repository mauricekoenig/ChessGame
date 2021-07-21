


using UnityEngine;

namespace MauriceKoenig.ChessGame
{
    public sealed class Square : MonoBehaviour
    {
        private ColorProperty ColorProperty { get; set; }
        private bool Initialized { get; set; }
        private Color32 ColorValue { get; set; }
        private SpriteRenderer Renderer { get; set; }
        private GameObject PreviewGraphic { get; set; }
        public BasePiece CurrentSubscriber;
        public string Notation { get; private set; }
        public Vector2 Coordinates { get; private set; }

        private void Awake() {

            this.Initialized = false;
            this.Renderer = GetComponent<SpriteRenderer>();
            this.PreviewGraphic = transform.GetChild(0).gameObject;
            PreviewGraphic.SetActive(false);
        }
        public void BuildSquare(Vector2 coordinates, Color32 squareColor, ColorProperty colorProperty) {

            if (Initialized) return;
            this.Coordinates = coordinates;
            this.ColorValue = squareColor;
            this.Renderer.color = this.ColorValue;
            this.ColorProperty = colorProperty;
            this.Notation = ChessUtility.GetNotation(Coordinates);
            this.gameObject.name = Notation;
            this.Initialized = true;
        }
        public void EnablePreviewGraphic() {

            this.PreviewGraphic.SetActive(true);
        }
        public void DisablePreviewGraphic() {

            this.PreviewGraphic.SetActive(false);
        }
        /// <summary>
        /// Überschreibt alle notwendigen Daten und aktualisiert die Position. CalculateBoardValues wird ebenfalls aufgerufen.
        /// </summary>
        /// <param name="piece"></param>
        public void AddSubscriber(BasePiece piece) {

            this.CurrentSubscriber = piece;
            piece.UnderlyingSquare = this;
            piece.Coordinates = this.Coordinates;
            piece.transform.position = this.transform.position + new Vector3(0, 0, Constants.PieceZOffset);
            piece.gameObject.name = $"{piece.ColorProperty.ToString()} {piece.Name} {this.Notation}";
            ChessUtility.CalculateBoardValues();
        }
        public void RemoveSubscriber() {

            CurrentSubscriber = null;
        }


        /// <summary>
        /// Leichte Methode um Figuren nach dem Pin-Check wieder an ihre ursprüngliche Position
        /// zu bringen, ohne die gesamte "AddSubscriber"-Logik auszuführen, da Figur nur
        /// temporär entfernt wurde.
        /// </summary>
        /// <param name="piece"></param>
        [KingFlag]
        public void SetSubscriber(BasePiece piece) {
            if (CurrentSubscriber == null) CurrentSubscriber = piece;
            else return;
        }
    }
}