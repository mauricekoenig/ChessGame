
using UnityEngine;

namespace MauriceKoenig.ChessGame
{
    [BaseClass]
    [RequireComponent(typeof(Controller))]
    public abstract class BasePiece : MonoBehaviour
    {
        public abstract string Name { get; }
        public abstract int Value { get; }
        public string Notation { get; private set; }
        public Square UnderlyingSquare { get; set; }
        public abstract int InternalTurnCounter { get; set; }

        protected PieceBehaviour Behaviour;
        public SpriteRenderer Renderer { get; set; }
        public ColorProperty ColorProperty { get; private set; }
        public Vector2 Coordinates;

        protected virtual void Awake() {

            this.Behaviour = GetComponent<PieceBehaviour>();
            this.Renderer = GetComponent<SpriteRenderer>();
        }
        protected virtual void GetSprite() {
            // Overwritten by extender.
        }
        public virtual void BuildPiece(ColorProperty colorProperty, Square square) {

            this.ColorProperty = colorProperty;
            this.Coordinates = square.Coordinates;
            this.Notation = ChessUtility.GetNotation(Coordinates);
            this.gameObject.name = $"{this.ColorProperty.ToString()} {this.Name} {this.Notation}";
            square.AddSubscriber(this);
        }
    }
}