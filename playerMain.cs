using UnityEngine;

public class playerMain : MonoBehaviour
{
    // 可在Inspector調整的參數
    public float speed = 3f;
    public Vector2 initialDirection = Vector2.right;
    // 轉向平滑度（越大越快，建議0.1~1之間）
    [Range(0.01f, 1f)]
    public float turnSmoothness = 0.1f;

    private Vector2 moveDirection;
    private Vector2 lastDirection;
    private Vector2 targetDirection;
    private bool hasStartedMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveDirection = initialDirection.normalized;
        lastDirection = moveDirection;
        targetDirection = moveDirection;
    }

    // Update is called once per frame
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
    }

    void HandleInput()
    {
        Vector2 inputDir = Vector2.zero;
        // 只支援上下左右鍵的八方向（不支援WASD）
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
            inputDir = inputDir.normalized;
            // 檢查是否為180度掉頭
            if (inputDir != -lastDirection && inputDir != moveDirection)
            {
                targetDirection = inputDir;
                lastDirection = targetDirection;
            }
        }
        else
        {
            // 沒有輸入時，鎖定當前方向
            targetDirection = moveDirection;
        }
    }
}
