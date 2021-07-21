

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MauriceKoenig.ChessGame
{
    [PawnFlag]
    public sealed class RecruitActivator : MonoBehaviour
    {
        [SerializeField] 
        private PieceType pieceType;

        private void OnMouseDown() {

            Debug.Log("Ich werde erkannt!");
            if (Security.GlobalPermission) return;
            Recruit(GameUIManager.Instance.StoredPiece, GameUIManager.Instance.StoredCoordinates, GameUIManager.Instance.StoredColorField);

        }
        private void Recruit(BasePiece piece, Vector2 coordinates, ColorProperty colorProperty) {

            var pie = piece;
            var cor = coordinates;
            var col = colorProperty;

            pie.UnderlyingSquare.RemoveSubscriber();
            Board.Instance.Pieces.Remove(pie);
            Destroy(pie.gameObject);
            GameUIManager.Instance.RecruitWindow.SetActive(false);

            // meldet sich in der Liste und registert sich beim Feld.
            Board.Instance.CreatePiece(pieceType, col, ChessUtility.GetNotation(cor));
            ChessUtility.CalculateBoardValues();
            Security.Unlock();
            GameManager.Instance.ChangeActivePlayer();
        }
    }
}