



using System.Diagnostics;
using UnityEngine;

namespace MauriceKoenig.ChessGame
{
    [Singleton]
    public sealed class GameUIManager : MonoBehaviour
    {
        public GameObject RecruitWindow { get; set; }
        public static GameUIManager Instance;
        public Stopwatch Timer { get; set; }
        private bool ListeningForStopWatch { get; set; }

        [CacheProperty] public Vector2 StoredCoordinates { get; set; }
        [CacheProperty] public ColorProperty StoredColorField { get; set; }
        [CacheProperty] public BasePiece StoredPiece { get; set; }

        [DebuggingTool("Exposes the stopwatch.")] 
        public float elapsedTime;

        private void Awake() {

            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }
        private void Update() {

            if (ListeningForStopWatch) {

                elapsedTime = Timer.ElapsedMilliseconds / 1000;

                if (Timer.ElapsedMilliseconds / 1000 >= 30) {
                    ListeningForStopWatch = false;
                    Timer.Reset();
                    DefaultRecruitBehaviour();
                    return;
                }
            }
        }
        private void Start() {

            Timer = new Stopwatch();
            if (RecruitWindow != null) return;
            RecruitWindow = Resources.Load<GameObject>("Prefabs/RecruitWindow");
        }
        public void ShowPieces(GameObject gameObj, BasePiece piece) {

            RecruitWindow = Instantiate(RecruitWindow, gameObj.transform.position + new Vector3(.3f, 0, 0), Quaternion.identity);

            StoredPiece = piece;
            StoredCoordinates = piece.Coordinates;
            StoredColorField = piece.ColorProperty;
            RecruitWindow.SetActive(true);
            ListeningForStopWatch = true;
            Timer.Start();
        }
        private void DefaultRecruitBehaviour() {

            UnityEngine.Debug.Log("Hello World!");
        }
    }
}