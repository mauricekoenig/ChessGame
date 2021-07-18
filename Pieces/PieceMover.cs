

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class PieceMover : MonoBehaviour
{

    private Square raycastTarget;
    private PieceController controller;
    private Piece piece;
    private Camera mainCam;

    private List<Square> validMoves = new List<Square>();
    public bool HasPermissionToMove { get { return GameLogic.Instance.CurrentPlayer == piece.ColorProperty; } private set { } }

    private Vector3 origin;
    [SerializeField] private bool isDragging = false;

    private void Start () {

        mainCam = Camera.main;
        controller = GetComponent<PieceController>();
        piece = GetComponent<Piece>();
    }

    internal void PrepareFireRay() {

        if (!isDragging && HasPermissionToMove) {

            isDragging = true;
            origin = transform.position;
            EnableIgnoreRaycastLayerToAllPieces();
            Debug.Log("OnMouseDown");
        }
    }
    internal void FireRay() {

        if (isDragging && HasPermissionToMove) {

            transform.position = GetWorldPosition(transform);
            Debug.DrawRay(transform.position, Vector3.forward * 100);

            if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit)) {

                Debug.Log(hit.collider.name);
            }
        }
    }
    internal void ResolveFireRay() {

        while (isDragging) {

            DisableDragging();
            SendBackToOrigin();
            DisableIgnoreRaycastLayerToAllPieces();
        }
    }

    private void EnableIgnoreRaycastLayerToAllPieces() {

        foreach (var element in Board.Instance.Pieces.Where(x => x != piece)) {

            element.gameObject.layer = 2;
        }
    }
    private void DisableIgnoreRaycastLayerToAllPieces() {

        foreach (var element in Board.Instance.Pieces.Where(x => x != piece)) {

            element.gameObject.layer = 10;
        }
    }
    private Vector3 GetWorldPosition(Transform t) {

        var desiredPosition = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.nearClipPlane));
        return desiredPosition;
    }
    private void DisableDragging() {

        isDragging = false;
    }
    private void SendBackToOrigin() {

        this.transform.position = origin;
    }
}