using UnityEngine;
using System.Collections.Generic;

public class playerMain : MonoBehaviour
{

    public Transform bodyPrefab;

    public List<Transform> bodies = new List<Transform>();

    // 速度（スピード）| 速度
    [Header("スピード | 速度")]
    public float speed = 3f;


    // 方向転換のスムーズさ（ターンスムーズネス）| 轉向平滑度（越大越快，建議0.1~1之間）
    [Header("転換のスムーズさ | 轉向平滑度")]
    [Tooltip("値が 0 に近いほど少しずつ回転、1 で一気に90度回転。\n值越接近 0，每次轉角度越少；值為 1 時，一次轉 90 度。")]
    public float turnSmoothness = 0.1f;


    // 現在の移動方向（ムーブディレクション）| 當前移動方向
    private Vector2 moveDirection;


    // 最後の方向（ラストディレクション）| 上一次方向
    private Vector2 lastDirection;


    // 目標方向（ターゲットディレクション）| 目標方向
    private Vector2 targetDirection;


    // 移動開始フラグ（ハズスターテッドムービング）| 是否已開始移動
    private bool hasStartedMoving = false;

    // 新增：記錄主體歷史位置
    private List<Vector3> positions = new List<Vector3>();
    // 每個 body 節點之間的距離（可調整）
    public float bodySpacing = 0.2f;







    void Start()
    {
        // 初始化為零向量，直到有輸入才開始移動
        moveDirection = Vector2.zero;
        lastDirection = Vector2.zero;
        targetDirection = Vector2.zero;

        bodies.Add(transform);
        positions.Add(transform.position); // 初始化時記錄主體位置
    }




    void Update()
    {
        HandleInput();
        if (hasStartedMoving)
        {
            // 平滑轉向
            moveDirection = Vector2.Lerp(moveDirection, targetDirection, turnSmoothness);
            moveDirection = moveDirection.normalized;
            transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
        }

        // 記錄主體位置
        if (positions.Count == 0 || (positions[positions.Count - 1] - transform.position).sqrMagnitude > 0.0001f)
        {
            positions.Add(transform.position);
        }

        // 控制 positions 長度，避免無限增長
        int maxPositions = Mathf.CeilToInt((bodies.Count + 1) * (1f / bodySpacing));
        while (positions.Count > maxPositions)
        {
            positions.RemoveAt(0);
        }

        // 讓每個 body 跟隨主體過去的位置
        for (int i = 1; i < bodies.Count; i++)
        {
            int index = Mathf.Max(positions.Count - 1 - Mathf.RoundToInt(i / bodySpacing), 0);
            bodies[i].position = positions[index];
        }

        // 移動圖片跟著旋轉
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -angle);
        }
    }




    void HandleInput()
    {
        // 入力方向（インプットディレクション）| 輸入方向
        Vector2 inputDir = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
            inputDir += Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow))
            inputDir += Vector2.down;
        if (Input.GetKey(KeyCode.LeftArrow))
            inputDir += Vector2.left;
        if (Input.GetKey(KeyCode.RightArrow))
            inputDir += Vector2.right;

        if (inputDir != Vector2.zero)
        {
            if (!hasStartedMoving)
                hasStartedMoving = true;

            // 正規化（ノーマライズ）| 正規化
            inputDir = inputDir.normalized;

            // 檢查是否為180度掉頭
            if (inputDir != -lastDirection && inputDir != moveDirection)
            {
                // 目標方向設定（ターゲットディレクションセット）| 設定目標方向
                targetDirection = inputDir;
                // 最後方向更新（ラストディレクションアップデート）| 更新最後方向
                lastDirection = targetDirection;
            }
        }
        else
        {
            // 沒有輸入時，鎖定當前方向
            // 目標方向維持（ターゲットディレクションキープ）| 維持目標方向
            targetDirection = moveDirection;
        }
    }

    //タグが "Food" の場合プレハブを生成 | 當碰撞隕石 標籤名"food" 啟用碰撞
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            // 新增 body 時，將其位置設為最後一個 body 的位置
            Transform newBody = Instantiate(bodyPrefab, bodies[bodies.Count - 1].position, Quaternion.identity);
            bodies.Add(newBody);
        }
    }
}
