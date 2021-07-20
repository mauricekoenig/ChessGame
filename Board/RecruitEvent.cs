

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class RecruitEvent : MonoBehaviour
{
    private Sprite sprite;
    [SerializeField] private PieceType pieceType;

    private void Awake() {
        sprite = GetComponent<Image>().sprite;
    }

    private void OnMouseDown () {

        Debug.Log("Ich werde erkannt!");
        if (Security.GlobalPermission) return;
        Recruit(GameUIManager.Instance.StoredPiece, GameUIManager.Instance.StoredCoordinates, GameUIManager.Instance.StoredColorField);

    }

    private void Recruit (Piece piece, Vector2 coordinates, ColorField color) {

        var pie = piece;
        var cor = coordinates;
        var col = color;

        pie.CurrentlySubscribedTo.RemoveSubscriber();
        Board.Instance.Pieces.Remove(pie);
        Destroy(pie.gameObject);
        GameUIManager.Instance.RecruitWindow.SetActive(false);

        // meldet sich in der Liste und registert sich beim Feld.
        Board.Instance.CreatePiece(pieceType, col, ChessUtil.GetNotation(cor));
        ChessUtil.CalculateBoardValues();
        Security.Unlock();
        GameLogic.Instance.ChangeActivePlayer();
    }
}