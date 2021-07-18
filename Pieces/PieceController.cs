


using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class PieceController : MonoBehaviour
{
    private Piece piece;
    private PieceBehaviour pieceBehaviour;
    private List<Square> validMoves = new List<Square>();
    public bool HasPermissionToMove { get { return GameLogic.Instance.CurrentPlayer == piece.ColorProperty; } private set { } }

    private Camera mainCam;
    [SerializeField] private Vector3 origin;
    private bool isDragging = false;
    private object raycastTarget;
    [SerializeField] private Square raycastTargetSquare;
    [SerializeField] private Piece raycastTargetPiece;

   

    private void Start () {

        mainCam = Camera.main;
        piece = GetComponent<Piece>();
        pieceBehaviour = GetComponent<PieceBehaviour>();
    }
    private Vector3 GetWorldPosition (Transform t) {

        var desiredPosition = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.nearClipPlane));
        return desiredPosition;
    }
    private void DisableDragging() {

        isDragging = false;
    }
    private void SendBackToOrigin() {

        this.transform.position = origin;
    }



    private void OnMouseDown() {
        
        if (!isDragging && HasPermissionToMove) {

            isDragging = true;
            origin = transform.position;
            Debug.Log("OnMouseDown");

            foreach (var element in Board.Instance.Pieces.Where(x => x != piece)) {

                element.gameObject.layer = 2;
            }
        }
    }

    private void OnMouseDrag() {

        if (isDragging && HasPermissionToMove) {

            transform.position = GetWorldPosition(transform);

            if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit)) {

                raycastTarget = hit.collider.gameObject;
            }

            Debug.DrawRay(transform.position, Vector3.forward * 100);
        }
    }


}