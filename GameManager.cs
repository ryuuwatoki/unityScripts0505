using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerM;
    public GameObject meteorite;
    public GameObject blackholeBig;
    public GameObject blackholeSmall;
    public GameObject blackholeBG;
    public Button startButton;
    public GameObject gameOverInfo;
    public Button restartButton;
    public GameUI gameUI;
    public static bool playerHasMoved = false;

    private bool gameStarted = false;
    private Vector3 playerMStartPos;
    private Vector3 meteoriteStartPos;
    private Vector3 blackholeBigStartPos;
    private Vector3 blackholeSmallStartPos;
    private Vector3 blackholeBGStartPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 遊戲一開始全部凍結
        SetGameObjectsActive(false);
        startButton.onClick.AddListener(OnStartButtonClicked);
        playerMStartPos = playerM.transform.position;
        meteoriteStartPos = meteorite.transform.position;
        blackholeBigStartPos = blackholeBig.transform.position;
        blackholeSmallStartPos = blackholeSmall.transform.position;
        blackholeBGStartPos = blackholeBG.transform.position;
        gameOverInfo.SetActive(false);
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    void OnStartButtonClicked()
    {
        SetGameObjectsActive(true);
        gameStarted = true;
        playerHasMoved = false;
        // playerM 需等到按下方向鍵才解凍
        playerM.GetComponent<playerMain>().enabled = false;
    }

    public void OnplayerMDied()
    {
        SetGameObjectsActive(false);
        gameStarted = false;
        playerM.GetComponent<playerMain>().enabled = false;
        // 顯示遊戲結束資訊和重啟按鈕
        gameOverInfo.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    void SetGameObjectsActive(bool isActive)
    {
        playerM.SetActive(isActive);
        meteorite.SetActive(isActive);
        blackholeBig.SetActive(isActive);
        blackholeSmall.SetActive(isActive);
        blackholeBG.SetActive(isActive);
    }

    public void ResetAllObjectsPosition()
    {
        playerM.transform.position = playerMStartPos;
        meteorite.transform.position = meteoriteStartPos;
        blackholeBig.transform.position = blackholeBigStartPos;
        blackholeSmall.transform.position = blackholeSmallStartPos;
        blackholeBG.transform.position = blackholeBGStartPos;
    }

    void OnRestartButtonClicked()
    {
        // 隱藏遊戲結束資訊和重啟按鈕
        gameOverInfo.SetActive(false);
        restartButton.gameObject.SetActive(false);
        // 重新啟用所有物件
        SetGameObjectsActive(true);
        ResetAllObjectsPosition();
        playerM.GetComponent<playerMain>().ResetStage();
        gameStarted = true;
        playerHasMoved = false;
        playerM.GetComponent<playerMain>().enabled = false;

        // 這裡歸零分數
        gameUI.RestScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted && !playerM.GetComponent<playerMain>().enabled)
        {
            // 檢查是否有按下方向鍵
            if (Input.GetKeyDown(KeyCode.UpArrow) ||
                Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.LeftArrow) ||
                Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerM.GetComponent<playerMain>().enabled = true;
                playerHasMoved = true;
            }
        }
    }
}
