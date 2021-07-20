

using UnityEngine;

public sealed class GetCameraScript : MonoBehaviour
{
    private Canvas canvas;

    private void Awake() {

        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }
}
