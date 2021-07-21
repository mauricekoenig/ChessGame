

using UnityEngine;

namespace MauriceKoenig.ChessGame
{
    public sealed class CameraGetter : MonoBehaviour
    {
        private Canvas canvas;

        private void Awake() {

            canvas = GetComponent<Canvas>();
            canvas.worldCamera = Camera.main;
        }
    }

}