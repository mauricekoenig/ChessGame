



using System.Diagnostics;
using UnityEngine;


public class GameUIManager : MonoBehaviour
{
    public GameObject RecruitWindow { get; set; }
    public static GameUIManager Instance;
    public Stopwatch stopwatch = new Stopwatch();
    public bool listenForStopwatch;
    public Vector2 StoredCoordinates { get; set; }
    public ColorField StoredColorField { get; set; }
    public Piece StoredPiece { get; set; }
    public float elapsedTime;

    private void Awake() {

        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update() {

        if (listenForStopwatch) {

            elapsedTime = stopwatch.ElapsedMilliseconds / 1000;

            if (stopwatch.ElapsedMilliseconds / 1000 >= 30) {
                listenForStopwatch = false;
                stopwatch.Reset();
                DefaultRecruitBehaviour();
                return;
            }
        }
    }
    private void Start() {

        if (RecruitWindow != null) return;
            RecruitWindow = Resources.Load<GameObject>("Prefabs/RecruitWindow");
    }

    public void ShowPieces (GameObject gameObj, Piece piece) {

        RecruitWindow = Instantiate(RecruitWindow, gameObj.transform.position + new Vector3(.3f, 0, 0), Quaternion.identity);

         StoredPiece = piece;
         StoredCoordinates = piece.Coordinates;
         StoredColorField = piece.ColorProperty;
              RecruitWindow.SetActive(true);
                listenForStopwatch = true;
                        stopwatch.Start();
    }

    private void DefaultRecruitBehaviour() {

        UnityEngine.Debug.Log("Hello World!");
    }

}